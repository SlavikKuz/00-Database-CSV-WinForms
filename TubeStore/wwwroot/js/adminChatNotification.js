function getChatNotification() {
    var res = "Waiting aswer: ";
    $.ajax({
        url: "/Notification/getChatNotification",
        method: "GET",
        success: function (result) {
            var notifications = result.chatGroups;
            notifications.forEach(element => {
                res = res + "<span class='badge badge-primary group-id mx-1' data-id='" + element + "'>" + "id=" + element + "</span>";
            });

            $("#adminChat").html(res);

            console.log(result);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

var groupAdminId;

$("div").on('click', 'span.group-id', function (e) {
    var target = e.target;
    var id = $(target).data('id');
    groupAdminId = id;
    readChatNotification(id);
    e.stopPropagation ? e.stopPropagation() : e.cancelBubble = true;
})

function readChatNotification(id) {
    $.ajax({
        url: "/Notification/ReadChatNotification",
        method: "GET",
        data: { groupId: id },
        success: function () {
            getChatNotification();
            reloadPartial();
            sendGroupidToHub(id);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

getChatNotification();

const hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("/chatHub")
      .build();

hubConnection.start()
    .catch(error => {
        console.error(error.message);
    });

hubConnection.on('receiveAdminChatMessages', addMessagesToAdminChat);
hubConnection.on('receiveChatMessage', addMessageToAdminChat);

function sendGroupidToHub(id) {
    hubConnection.invoke('getChatMessagesAdmin', id);
}

function sendAdminMessageToHub(text, groupAdminId) {
    hubConnection.invoke('sendAdminToGroup', text, groupAdminId);
}

document.getElementById('submitButton').addEventListener('click', () => {
    clearInputField();
    sendMessage();
});

var messageText = document.getElementById('messageText');
var messagesQueue = [];

function clearInputField() {
    messagesQueue.push(messageText.value);
    messageText.value = "";
}

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;

    sendAdminMessageToHub(text, groupAdminId);
}


function reloadPartial() {
    $('#adminReload').load('ChatWindow');
}

function addMessagesToAdminChat(lastMessages) {
    var chatAdmin = document.getElementById('adminChatMessages');

    for (i = 0; i < lastMessages.length; i++) {

        let isCurrentUserMessage = lastMessages[i].customerId === userId;

        let container = document.createElement('div');
        container.className = isCurrentUserMessage ? "direct-chat-msg right" : "direct-chat-msg";

        let childContainer = document.createElement('div');
        childContainer.className = "direct-chat-infos clearfix";

        let sender = document.createElement('span');
        sender.className = isCurrentUserMessage ? "direct-chat-name float-right" : "direct-chat-name float-left";
        sender.innerHTML = lastMessages[i].userName;

        let date = document.createElement('span');
        date.className = isCurrentUserMessage ? "direct-chat-timestamp float-left" : "direct-chat-timestamp float-right";
        date.innerHTML = lastMessages[i].messageDate;

        let message = document.createElement('div');
        message.className = "direct-chat-text";
        message.innerHTML = lastMessages[i].messageText;

        childContainer.appendChild(sender);
        childContainer.appendChild(date);
        container.appendChild(message);
        container.appendChild(childContainer);
        chatAdmin.appendChild(container);
    }
}

function addMessageToAdminChat(adminMessage) {
    var chatAdmin = document.getElementById('adminChatMessages');

    let isCurrentUserMessage = adminMessage.customerId === userId;

    let container = document.createElement('div');
    container.className = isCurrentUserMessage ? "direct-chat-msg right" : "direct-chat-msg";

    let childContainer = document.createElement('div');
    childContainer.className = "direct-chat-infos clearfix";

    let sender = document.createElement('span');
    sender.className = isCurrentUserMessage ? "direct-chat-name float-right" : "direct-chat-name float-left";
    sender.innerHTML = adminMessage.userName;

    let date = document.createElement('span');
    date.className = isCurrentUserMessage ? "direct-chat-timestamp float-left" : "direct-chat-timestamp float-right";
    date.innerHTML = adminMessage.messageDate;

    let message = document.createElement('div');
    message.className = "direct-chat-text";
    message.innerHTML = adminMessage.messageText;

    childContainer.appendChild(sender);
    childContainer.appendChild(date);
    container.appendChild(message);
    container.appendChild(childContainer);
    chatAdmin.appendChild(container);
}