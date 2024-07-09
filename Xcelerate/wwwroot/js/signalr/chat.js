document.addEventListener("DOMContentLoaded", function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    document.getElementById("sendButton").disabled = true;
    document.getElementById("sendButtonOffer").disabled = true;

    var currentUserId = document.getElementById("currentUserId").value;

    connection.on("ReceiveMessage", function (user, message) {
        var li = document.createElement("li");
        document.getElementById("messagesList").appendChild(li);
        li.textContent = `${user} says ${message}`;
    });

    function addOfferToUI(user, message, offerId, senderId, buyerId) {
        var li = document.createElement("li");
        li.textContent = `${user} offers ${message}$`;
        li.setAttribute("data-offer-id", offerId); // Ensure offerId is set as integer

        var acceptButton = document.createElement("button");
        acceptButton.textContent = "Accept";
        acceptButton.onclick = function () {
            var urlParams = new URLSearchParams(window.location.search);
            var carId = urlParams.get('carId');
            console.log(buyerId);

            Swal.fire({
                title: 'Are you sure?',
                text: "If you accept this offer, you will buy the car.",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, buy it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    var token = $('input[name="__RequestVerificationToken"]').val();
                    console.log('Token:', token);  // Debug token

                    $.ajax({
                        url: '/Ad/Buy',
                        type: 'POST',
                        data: {
                            carId: carId,
                            buyerId: buyerId,
                            confirmedPrice: parseFloat(message),
                            __RequestVerificationToken: token
                        },
                        success: function () {
                            console.log('Buy request successful');
                            window.location.href = '/UserCars/Index';  // Redirect to user's cars page
                        },
                        error: function (xhr, status, error) {
                            console.error('Error response text:', xhr.responseText);
                            console.error('Status:', status);
                            console.error('Error thrown:', error);

                            // Display a detailed error message to the user
                            Swal.fire({
                                title: 'Error!',
                                text: `An error occurred: ${xhr.responseText || 'Unknown error'}`,
                                icon: 'error',
                                confirmButtonText: 'Ok'
                            });
                        }
                    });

                }
            });
        };

        // Append acceptButton to your UI as needed




        var declineButton = document.createElement("button");
        declineButton.textContent = "Decline";
        declineButton.onclick = function () {
            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, decline it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    connection.invoke("DeclineOffer", parseInt(offerId, 10)).catch(function (err) {
                        console.error('Error declining offer:', err);
                    });
                }
            });
        };

        if (currentUserId === senderId) {
            // Sender can only see Decline button
            acceptButton.style.display = "none";
        } else {
            // Recipient can see both Accept and Decline buttons
            declineButton.style.display = "inline-block"; // Ensure decline button is displayed for recipient
        }

        li.appendChild(acceptButton);
        li.appendChild(declineButton);
        document.getElementById("messagesOfferList").appendChild(li);
    }

    connection.on("ReceiveOfferMessage", function (user, message, offerId, senderId, buyerId) {
        addOfferToUI(user, message, offerId, senderId, buyerId);
    });

    connection.on("OfferDeclined", function (offerId) {
        // Remove the declined offer from the UI
        var offerElement = document.querySelector(`[data-offer-id='${offerId}']`);
        if (offerElement) {
            offerElement.remove();
        }
    });

    connection.start().then(function () {
        var sessionId = document.getElementById("sessionId").value;
        connection.invoke("JoinChat", sessionId).catch(function (err) {
            console.error('Error joining chat:', err);
        });
        connection.invoke("LoadChatMessages", sessionId).catch(function (err) {
            console.error('Error loading chat messages:', err);
        });

        connection.invoke("LoadChatOffers", sessionId).catch(function (err) {
            console.error('Error loading chat offers:', err);
        });

        document.getElementById("sendButton").disabled = false;
        document.getElementById("sendButtonOffer").disabled = false;
    }).catch(function (err) {
        console.error('SignalR connection error:', err);
    });

    // Function to handle Send message button click
    document.getElementById("sendButton").addEventListener("click", function (event) {
        var message = document.getElementById("messageInput").value;
        var sessionId = document.getElementById("sessionId").value;
        connection.invoke("SendMessage", sessionId, message).catch(function (err) {
            console.error('Error sending message:', err);
        });
        event.preventDefault();
    });

    // Function to handle Send offer button click
    document.getElementById("sendButtonOffer").addEventListener("click", function (event) {
        var message = document.getElementById("messageOfferInput").value;
        var sessionId = document.getElementById("sessionId").value;

        connection.invoke("SendOffer", sessionId, message).catch(function (err) {
            console.error('Error sending offer:', err);
        });
        event.preventDefault();
    });
});
