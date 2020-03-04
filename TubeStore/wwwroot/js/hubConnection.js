const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

//hubConnection.on('receiveMessage', addMessageToChat);

hubConnection.on('receiveMessages', addMessagesToChat);

hubConnection.on('receiveMessage', addMessageToChat);

//hubConnection.on('connected', connectUser);

hubConnection.start()
    .catch(error => {
        console.error(error.message);
    });

function sendMessageToHub(text) {
    hubConnection.invoke('sendToGroup', text);
}



//function connectUser(connectionId) {
//    var groupElement = document.getElementById("group");
//    var option = document.createElement("option");
//    option.text = connectionId;
//    option.value = connectionId;
//    groupElement.add(option);
//}