class ChatMessage {
    constructor(groupId, user, message, date) {
        this.chatGroupId = groupId;
        this.userName = user;
        this.messageText = message;
        this.messageDate = date;
    }
}

const messageText = document.getElementById('messageText');
const chat = document.getElementById('chat');
const messagesQueue = [];
const date = document.getElementById('MessageDate');

function clearInputField() {
    messagesQueue.push(messageText.value);
    messageText.value = "";
}

document.getElementById('submitButton').addEventListener('click', () => {
    var currentdate = new Date();
    currentdate.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
});

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;

    let date = new Date();
    let message = new ChatMessage(chatGroupId, userName, text, date);
    sendMessageToHub(message);
}

function addMessageToChat(message) {
    let isCurrentUserMessage = message.userName === userName;

    let container = document.createElement('div');
    container.className = isCurrentUserMessage ? "container darker" : "container";

    let sender = document.createElement('p');
    sender.className = "sender";
    sender.innerHTML = message.userName;
    let text = document.createElement('p');
    text.innerHTML = message.messageText;

    let date = document.createElement('span');
    date.className = isCurrentUserMessage ? "time-left" : "time-right";
    var currentdate = new Date();
    date.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

    container.appendChild(sender);
    container.appendChild(text);
    container.appendChild(date);
    chat.appendChild(container);
}
