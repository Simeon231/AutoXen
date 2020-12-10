// if the document contains chat
if (document.getElementById("messagesList") != null) {
    const request = document.getElementById('requestId');
    let requestId;
    if (request != null) {
        requestId = request.value;
    }

    var messageList = document.getElementById("messagesList");
    messageList.scrollTop = messageList.scrollHeight;

    if (requestId != null) {
        let messagesCount = document.getElementById("messagesCount");

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

                let scrollBottom = false;
                if (messageList.scrollTop - messageList.scrollHeight + messageList.offsetHeight > -1) {
                    scrollBottom = true;
                }

                messageList.append(chatMsg);

                if (scrollBottom) {
                    messageList.scrollTop = messageList.scrollHeight;
                }

                messagesCount.textContent = parseInt(messagesCount.textContent) + 1;
            });
    }

    document.getElementById('messageInput').addEventListener('keyup', (e) => {
        if (e.key === "Enter" || e.which === 13 || e.keyCode === 13) {
            e.preventDefault();

            sendMsg();
        }
    })

    $("#sendButton").click(function (e) {
        e.preventDefault();

        sendMsg();
    });

    function sendMsg() {
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

        let scrollBottom = false;
        if (messageList.scrollTop - messageList.scrollHeight + messageList.offsetHeight > -1) {
            scrollBottom = true;
        }

        messageList.append(chatMsg);

        if (scrollBottom) {
            messageList.scrollTop = messageList.scrollHeight;
        }

        $("#messageInput").val("");
        messagesCount.textContent = parseInt(messagesCount.textContent) + 1;
    }

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