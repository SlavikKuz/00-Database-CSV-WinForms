
document.getElementById("joinGroup").addEventListener("click", function (event) {
    hubConnection.invoke("joinGroup").catch(function (err) {
        return console.error(err.toString());
    });
    //hubConnection.invoke("requestLastMessages").catch(function (err) {
    //    return console.error(err.toString());
    //});
    event.preventDefault();
});


//class ChatMessage {
//    constructor(groupId, user, message, date) {
//        this.chatGroupId = groupId;
//        this.userName = user;
//        this.messageText = message;
//        this.messageDate = date;
//    }
//}

const messageText = document.getElementById('messageText');
const chat = document.getElementById('chat');
const messagesQueue = [];
//const date = document.getElementById('MessageDate');

function clearInputField() {
    messagesQueue.push(messageText.value);
    messageText.value = "";
}

//document.getElementById('submitButton').addEventListener('click', () => {
//    var currentdate = new Date();
//    currentdate.innerHTML =
//        (currentdate.getMonth() + 1) + "/"
//        + currentdate.getDate() + "/"
//        + currentdate.getFullYear() + " "
//        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
//});

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;

    //let date = new Date();
    //let message = new ChatMessage(chatGroupId, userName, text, date);
    sendMessageToHub(text);
}

function addMessagesToChat(lastMessages) {
    for (i = 0; i < lastMessages.length; i++) {
        //check id?
        let isCurrentUserMessage = lastMessages[i].customerId === userId;

        let container = document.createElement('div');
        container.className = isCurrentUserMessage ? "lighter float-right" : "darker float-left";

        let text = document.createElement('p');
        text.innerHTML = lastMessages[i].messageText;

        //var currentdate = lastMessages[i].messageDate;
        //date.innerHTML =
        //    (currentdate.getMonth() + 1) + "/"
        //    + currentdate.getDate() + "/"
        //    + currentdate.getFullYear() + " "
        //    + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

        let sender = document.createElement('div');
        sender.className = "badge";
        sender.innerHTML = lastMessages[i].userName + ", posted " + lastMessages[i].messageDate;

        container.appendChild(text);
        container.appendChild(sender);
        chat.appendChild(container);
    }
}

function addMessageToChat(chatMessage) {

        let isCurrentUserMessage = chatMessage.customerId === userId;

        let container = document.createElement('div');
        container.className = isCurrentUserMessage ? "lighter float-right" : "darker float-left";

        let text = document.createElement('p');
        text.innerHTML = chatMessage.messageText;

        //var currentdate = lastMessages[i].messageDate;
        //date.innerHTML =
        //    (currentdate.getMonth() + 1) + "/"
        //    + currentdate.getDate() + "/"
        //    + currentdate.getFullYear() + " "
        //    + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

        let sender = document.createElement('div');
        sender.className = "badge";
        sender.innerHTML = chatMessage.userName + ", posted " + chatMessage.messageDate;

        container.appendChild(text);
        container.appendChild(sender);
        chat.appendChild(container);
}



//function addMessageToChat(message) {
//    let isCurrentUserMessage = message.userName === userName;

//    let container = document.createElement('div');
//    container.className = isCurrentUserMessage ? "container darker" : "container";

//    let sender = document.createElement('p');
//    sender.className = "sender";
//    sender.innerHTML = message.userName;
//    let text = document.createElement('p');
//    text.innerHTML = message.messageText;

//    let date = document.createElement('span');
//    date.className = isCurrentUserMessage ? "time-left" : "time-right";
//    var currentdate = new Date();
//    date.innerHTML =
//        (currentdate.getMonth() + 1) + "/"
//        + currentdate.getDate() + "/"
//        + currentdate.getFullYear() + " "
//        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

//    container.appendChild(sender);
//    container.appendChild(text);
//    container.appendChild(date);
//    chat.appendChild(container);
//}




//document.getElementById("joinGroup").addEventListener("click", function (event) {
//    hubConnection.invoke("joinGroup").catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});

//document.getElementById("joinGroup").addEventListener("click", function (event) {
//    var model = { name: userName, group: chatGroupId };
//    $.ajax({
//        url: "/Home/Chat",
//        type: 'POST',
//        data: JSON.stringify(model),
//        contentType: "application/json",
//        success: function (data) {
//            alert("Administrator will connect as soon as possible!");
//            window.location.replace(data.newUrl);
//        },
//        error: function () {
//            alert(":(");
//        }
//    });
//    event.preventDefault();
//});