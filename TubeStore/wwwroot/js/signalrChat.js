const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

hubConnection.on('receiveMessage', addMessageToChat);

hubConnection.on('connected', connectUser);

hubConnection.start()
    .catch(error => {
        console.error(error.message);
    });

function sendMessageToHub(message) {
    hubConnection.invoke('sendToGroup', message);
}

function connectUser(connectionId) {
    var groupElement = document.getElementById("group");
    var option = document.createElement("option");
    option.text = connectionId;
    option.value = connectionId;
    groupElement.add(option);
}