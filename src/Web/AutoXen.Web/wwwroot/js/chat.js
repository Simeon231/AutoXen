// if the document contains chat
if (document.getElementById("messagesList") != null) {
    const request = document.getElementById('requestId');
    let requestId;
    if (request != null) {
        requestId = request.value;
    }

    if (requestId != null) {
        var connection =
            new signalR.HubConnectionBuilder()
                .withUrl("/chat")
                .build();

        connection.start()
            .then(() => connection.invoke("JoinGroup", requestId))
            .catch(function (err) {
                return console.error(err.toString());
            });

        connection.on("NewMessage",
            function (message) {
                console.log("here");
                var chatMsg = document.createElement("div");
                chatMsg.className = "direct-chat-msg";

                var chatInfo = document.createElement("div");
                chatInfo.className = "direct-chat-info clearfix";

                var time = document.createElement("span");
                time.className = "direct-chat-timestamp pull-right";
                const fmt = 'DD/MM/YYYY HH:mm:ss';
                time.textContent = moment().format(fmt);
                chatInfo.append(time);
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
    }

    var messageList = document.getElementById("messagesList");
    messageList.scrollTop = messageList.scrollHeight;

    $("#sendButton").click(function () {
        var message = $("#messageInput").val();
        message = message.trim();
        if (message.length < 1) {
            return;
        }

        if (requestId != null) {
            connection.invoke("Send", message, requestId);
        }

        var chatMsg = document.createElement("div");
        chatMsg.className = "direct-chat-msg right";

        var chatInfo = document.createElement("div");
        chatInfo.className = "direct-chat-info clearfix";

        var time = document.createElement("span");
        time.className = "direct-chat-timestamp pull-left";
        const fmt = 'DD/MM/YYYY HH:mm:ss';
        time.textContent = moment().format(fmt);

        chatInfo.append(time);
        chatMsg.append(chatInfo);

        var txt = document.createElement("div");
        txt.className = "direct-chat-text";
        txt.textContent = message;
        chatMsg.append(txt);

        messageList.append(chatMsg);

        $("#messageInput").val("");
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