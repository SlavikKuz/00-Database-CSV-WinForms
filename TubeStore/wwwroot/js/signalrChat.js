const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

hubConnection.on('receiveMessage', addMessageToChat);

hubConnection.start()
    .catch(error => {
        console.error(error.message);
    });

function sendMessageToHub(message) {
    hubConnection.invoke('sendToGroup', message);
}