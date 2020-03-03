
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