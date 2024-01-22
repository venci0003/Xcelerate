//document.querySelector('.register-button-submit').addEventListener('click', function () {
//    toggleLoginCard('none', true); // Close the login form with fade-out effect
//    toggleInputFields(false);
//    setTimeout(() => {
//        toggleRegisterCard('flex', true); // Open the register form with fade-in effect
//    }, 200); // Adjust the delay to match the duration of the fade-out effect
//});

//document.querySelector('.login-button-submit').addEventListener('click', function () {
//    toggleRegisterCard('none', true); // Close the register form with fade-out effect
//    toggleInputFields(false);
//    setTimeout(() => {
//        toggleLoginCard('flex', true); // Open the login form with fade-in effect
//    }, 200); // Adjust the delay to match the duration of the fade-out effect
//});

//document.querySelector('#minimizeIcon-register').addEventListener('click', function () {
//    toggleRegisterCard('none', false); // Close the register form without fade-out effect
//    toggleInputFields(true);
//});

//document.querySelector('#minimizeIcon-login').addEventListener('click', function () {
//    toggleLoginCard('none', false); // Close the login form without fade-out effect
//    toggleInputFields(true);
//});



//function toggleRegisterCard(activity, withFade) {
//    const cardRegister = document.querySelector('.card-register');
//    if (withFade) {
//        cardRegister.style.transition = 'opacity 0.5s ease-in-out';
//        cardRegister.style.opacity = '0';
//        setTimeout(() => {
//            cardRegister.style.transition = 'none';
//            cardRegister.style.display = activity;
//            setTimeout(() => {
//                cardRegister.style.transition = 'opacity 0.5s ease-in-out';
//                cardRegister.style.opacity = '1';
//            }, 20);
//        }, 200);
//    } else {
//        cardRegister.style.opacity = '0';
//        setTimeout(() => {
//            cardRegister.style.display = activity;
//            setTimeout(() => {
//                cardRegister.style.opacity = '1';
//            }, 20);
//        }, 200);
//    }
//}

//function toggleLoginCard(activity, withFade) {
//    const cardLogin = document.querySelector('.card-login');
//    if (withFade) {
//        cardLogin.style.transition = 'opacity 0.5s ease-in-out';
//        cardLogin.style.opacity = '0';
//        setTimeout(() => {
//            cardLogin.style.transition = 'none';
//            cardLogin.style.display = activity;
//            setTimeout(() => {
//                cardLogin.style.transition = 'opacity 0.5s ease-in-out';
//                cardLogin.style.opacity = '1';
//            }, 20);
//        }, 200);
//    } else {
//        cardLogin.style.opacity = '0';
//        setTimeout(() => {
//            cardLogin.style.display = activity;
//            setTimeout(() => {
//                cardLogin.style.opacity = '1';
//            }, 20);
//        }, 200);
//    }
//}


//function toggleInputFields(activity) {
//    const inputElements = Array.from(document.querySelectorAll('.card-content input'));

//    inputElements.forEach((input) => {
//        input.disabled = activity
//    });
//}

function updateClock() {
    var now = new Date(); // get the current date and time
    var hours = now.getHours();
    var minutes = now.getMinutes();
    var seconds = now.getSeconds();

    // Pad with a zero if needed
    if (hours < 10) hours = "0" + hours;
    if (minutes < 10) minutes = "0" + minutes;
    if (seconds < 10) seconds = "0" + seconds;

    // Format the time string
    var timeString = hours + ':' + minutes + ':' + seconds;

    // Update the time display
    document.getElementById('clock').textContent = timeString;

    // Call this function again in 1 second
    setTimeout(updateClock, 1000);
}

window.onload = updateClock; // start the clock when the page loads

const images = [
    '2022_honda_civic_1_1920x1080.jpg',
    '2021_honda_civic_type_r_9_1920x1080.jpg',
    '2024_nissan_gt-r_1_1920x1080.jpg',
    '2018_nissan_370z_heritage_edition_4_1920x1080.jpg',
    '2020-Mercedes-AMG-GT3---Front-Three-Quarter-201323-1920x1080.jpg',
    '2014_volvo_s60_1_1920x1080.jpg',
    '2023_audi_tt_rs_coupe_iconic_edition_1_1920x1080.jpg',
    '2022_audi_r8_us_1_1920x1080.jpg'
    // Add more image URLs as needed
];

let currentImageIndex = 0;

function changeBackgroundImage() {
    document.body.style.backgroundImage = `url(/Images/Home/${images[currentImageIndex]})`;
    currentImageIndex = (currentImageIndex + 1) % images.length;
    setTimeout(changeBackgroundImage, 5000); // Change image every 5 seconds
    console.log("Script is running");
}
changeBackgroundImage();

// Start the slideshow



