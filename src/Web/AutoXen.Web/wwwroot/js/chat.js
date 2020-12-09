// if the document contains chat
if (document.getElementById("messagesList") != null) {
    var connection =
        new signalR.HubConnectionBuilder()
            .withUrl("/chat")
            .build();

    var requestId = document.getElementById('requestId').value;
    var messageList = document.getElementById("messagesList");
    messageList.scrollTop = messageList.scrollHeight;

    connection.on("NewMessage",
        function (message) {
            console.log("here");
            var chatMsg = document.createElement("div");
            chatMsg.className = "direct-chat-msg";

            var chatInfo = document.createElement("div");
            chatInfo.className = "direct-chat-info clearfix";

            var span = document.createElement("span");
            span.className = "direct-chat-timestamp pull-right";
            const fmt = 'DD/MM/YYYY HH:mm:ss';
            span.textContent = moment().format(fmt);
            chatInfo.append(span);
            chatMsg.append(chatInfo);

            var img = document.createElement('img');
            img.className = 'direct-chat-img';
            img.src = "https://img.icons8.com/color/36/000000/administrator-male.png";
            chatMsg.append(img);

            var txt = document.createElement("div");
            txt.className = "direct-chat-text";
            txt.textContent = message;
            chatMsg.appendChild(txt);

            messageList.append(chatMsg);
        });

    $("#sendButton").click(function () {
        var message = $("#messageInput").val();
        message = message.trim();
        if (message.length < 1) {
            return;
        }

        connection.invoke("Send", message, requestId);

        var chatMsg = document.createElement("div");
        chatMsg.className = "direct-chat-msg right";

        var chatInfo = document.createElement("div");
        chatInfo.className = "direct-chat-info clearfix";

        var span = document.createElement("span");
        span.className = "direct-chat-timestamp pull-left";
        const fmt = 'DD/MM/YYYY HH:mm:ss';
        span.textContent = moment().format(fmt);

        chatInfo.append(span);
        chatMsg.append(chatInfo);

        var txt = document.createElement("div");
        txt.className = "direct-chat-text";
        txt.textContent = message;
        chatMsg.append(txt);

        messageList.append(chatMsg);

        $("#messageInput").val("");
    });

    connection.start()
        .then(() => connection.invoke("JoinGroup", requestId))
        .catch(function (err) {
            return console.error(err.toString());
        });

    function escapeHtml(unsafe) {
        return unsafe
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#039;");
    }

    // hide or show
    const minimize = document.getElementById('minimizeChat');
    const boxBody = document.getElementsByClassName('box-body')[0];
    const boxFooter = document.getElementsByClassName('box-footer')[0];

    minimize.addEventListener('click', () => {
        if (boxBody.hidden) {
            boxBody.hidden = false;
            boxFooter.hidden = false;
        }
        else {
            boxBody.hidden = true;
            boxFooter.hidden = true;
        }
    })
}