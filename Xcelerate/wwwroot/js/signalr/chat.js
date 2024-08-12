document.addEventListener("DOMContentLoaded", function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    var sendButton = document.getElementById("sendButton");
    var sendButtonOffer = document.getElementById("sendButtonOffer");

    var messageInput = document.getElementById("messageInput");
    var messageOfferInput = document.getElementById("messageOfferInput");

    var messageCooldownElement = document.getElementById("messageCooldown");
    var offerCooldownElement = document.getElementById("offerCooldown");

    var messageCooldown = 5;
    var offerCooldown = 60;

    function toggleButtonState() {
        sendButton.disabled = messageInput.value.trim() === '';
        sendButtonOffer.disabled = messageOfferInput.value.trim() === '' || messageOfferInput.value <= 0;
    }

    messageInput.addEventListener('input', toggleButtonState);
    messageOfferInput.addEventListener('input', toggleButtonState);

    toggleButtonState();

    function startCountdown(inputElement, cooldownTime, type, cooldownElement) {
        var timeLeft = cooldownTime;

        var interval = setInterval(function () {
            timeLeft--;
            cooldownElement.textContent = `${type} available in ${timeLeft}s`;

            if (timeLeft <= 0) {
                clearInterval(interval);
                inputElement.disabled = false;
                cooldownElement.textContent = '';
                toggleButtonState();
            }
        }, 1000);

        inputElement.disabled = true;
        cooldownElement.textContent = `${type} available in ${cooldownTime}s`;
    }

    connection.on("ReceiveMessage", function (user, message, senderId, buyerId, sellerId) {
        var li = document.createElement("li");

        if (senderId === sellerId) {
            li.classList.add("seller");
        } else if (senderId === buyerId) {
            li.classList.add("buyer");
        }

        li.textContent = `${user} says ${message}`;
        document.getElementById("messagesList").appendChild(li);
    });

    function addOfferToUI(user, offerMessage, offerId, senderId, buyerId, sellerId) {
        var li = document.createElement("li");
        li.textContent = `${user} offers ${offerMessage}$`;
        li.setAttribute("data-offer-id", offerId);

        if (senderId === sellerId) {
            li.classList.add("seller");
        } else if (senderId === buyerId) {
            li.classList.add("buyer");
        }

        var acceptButton = document.createElement("button");
        acceptButton.textContent = "Accept";
        acceptButton.onclick = function () {
            var urlParams = new URLSearchParams(window.location.search);
            var carId = urlParams.get('carId');

            Swal.fire({
                title: 'Are you sure?',
                text: "If you accept this offer, you will proceed with the car transaction.",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, accept the offer!'
            }).then((result) => {
                if (result.isConfirmed) {
                    var token = $('input[name="__RequestVerificationToken"]').val();

                    $.ajax({
                        url: '/Ad/Buy',
                        type: 'POST',
                        data: {
                            carId: carId,
                            buyerId: buyerId,
                            confirmedPrice: parseFloat(offerMessage),
                            __RequestVerificationToken: token
                        },
                        success: function () {
                            connection.invoke("AcceptOffer", buyerId, sellerId, parseFloat(offerMessage)).catch(function (err) {
                                console.error('Error invoking AcceptOffer:', err);
                            });
                        },
                        error: function (xhr, status, error) {
                            console.error('Error response text:', xhr.responseText);
                            console.error('Status:', status);
                            console.error('Error thrown:', error);

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
            acceptButton.style.display = "none";
        } else {
            declineButton.style.display = "inline-block";
        }

        li.appendChild(acceptButton);
        li.appendChild(declineButton);
        document.getElementById("messagesOfferList").appendChild(li);
    }

    connection.on("ReceiveOfferMessage", function (user, message, offerId, senderId, buyerId, sellerId) {
        addOfferToUI(user, message, offerId, senderId, buyerId, sellerId);
    });

    connection.on("OfferDeclined", function (offerId) {
        var offerElement = document.querySelector(`[data-offer-id='${offerId}']`);
        if (offerElement) {
            offerElement.remove();
        }
    });

    connection.on("OfferAccepted", function (redirectUrl, message, offerMessage) {
        if (redirectUrl) {
            sessionStorage.setItem('notificationMessage', message);
            sessionStorage.setItem('offerAmount', offerMessage);
            window.location.href = redirectUrl;
        } else {
            console.error("Received an invalid redirect URL");
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

        toggleButtonState();
    }).catch(function (err) {
        console.error('SignalR connection error:', err);
    });

    function handleSendMessage(event) {
        var message = messageInput.value;
        var sessionId = document.getElementById("sessionId").value;
        connection.invoke("SendMessage", sessionId, message).catch(function (err) {
            console.error('Error sending message:', err);
        });

        startCountdown(messageInput, messageCooldown, "Message", messageCooldownElement);

        event.preventDefault();
        messageInput.value = '';
        toggleButtonState();
    }

    function handleSendOffer(event) {
        var offerValue = messageOfferInput.value;
        var sessionId = document.getElementById("sessionId").value;
        var isValid = true;

        $(".text-danger").text('');

        if (!offerValue || offerValue < 500) {
            isValid = false;
            $("#messageOfferInput").siblings(".text-danger").text("The offer must be at least $500.");
        }

        if (isValid) {
            connection.invoke("SendOffer", sessionId, offerValue).catch(function (err) {
                console.error('Error sending offer:', err);
            });

            startCountdown(messageOfferInput, offerCooldown, "Offer", offerCooldownElement);

            messageOfferInput.value = '';
            toggleButtonState();
        }
        event.preventDefault();
    }

    sendButton.addEventListener("click", handleSendMessage);
    sendButtonOffer.addEventListener("click", handleSendOffer);

    messageInput.addEventListener("keydown", function (event) {
        if (event.key === "Enter") {
            handleSendMessage(event);
        }
    });

    messageOfferInput.addEventListener("keydown", function (event) {
        if (event.key === "Enter") {
            handleSendOffer(event);
        }
    });
});
