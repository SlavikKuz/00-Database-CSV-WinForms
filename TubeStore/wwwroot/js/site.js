$(function () {
    $("#target").append('<div class="dropdown-menu" id="notification-content"></div>')

    function getNotification() {
        var res = "";
        $.ajax({
            url: "/Notification/getNotification",
            method: "GET",
            success: function (result) {

                if (result.count != 0) {
                    $("#notificationCount").html(result.count);
                    $("#notificationCount").show('slow');
                } else {
                    $("#notificationCount").html();
                    $("#notificationCount").hide('slow');
                    $("#notificationCount").popover('hide');
                }

                var notifications = result.userNotification;
                notifications.forEach(element => {
                    res = res + "<a class='list-group-item notification-text' data-id='" + element.notification.notificationId + "'>" + element.notification.notificationText + "</a>";
                });

                $("#notification-content").html(res);

                console.log(result);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    $("div").on('click', 'a.notification-text', function (e) {
        var target = e.target;
        var id = $(target).data('id');

        readNotification(id, target);
    })

    function readNotification(id, target) {
        $.ajax({
            url: "/Notification/ReadNotification",
            method: "GET",
            data: { notificationId: id },
            success: function (result) {
                getNotification();
                $(target).fadeOut('slow');
            },
            error: function (error) {
                console.log(error);
            }
        })
    }

    getNotification();

    let hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/chatHub")
        .build();


    hubConnection.on('displayNotification', () => {
        getNotification();
    });

    hubConnection.start()
        .catch(error => {
            console.error(error.message);
        });

});

