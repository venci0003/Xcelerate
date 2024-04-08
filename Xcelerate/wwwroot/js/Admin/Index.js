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
    '2020_ac_schnitzer_toyota_gr_supra_1_1920x1080.jpg',
    '2017-Mercedes-AMG-GT-4-Door-Concept---Front-Three-Quarter-147215-1920x1080.jpg',
    '2023_bmw_ix_m60_1_1920x1080.jpg',
    '2014-Maserati-GranTurismo-MC-Stradale----Front-53190-1920x1080.jpg',
    '2021_bugatti_chiron_super_sport_300plus_1_1920x1080.jpg',
    '2023_porsche_718_style_edition_1_1920x1080.jpg',
    '2023_acura_integra_16_1920x1080.jpg'
];

let currentImageIndex = 0;

function changeBackgroundImage() {
    document.body.style.backgroundImage = `url(/Images/Home/${images[currentImageIndex]})`;
    currentImageIndex = (currentImageIndex + 1) % images.length;
    setTimeout(changeBackgroundImage, 5000); // Change image every 5 seconds
    console.log("Script is running");
}
changeBackgroundImage();