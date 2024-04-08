function updateClock() {
    var now = new Date(); // get the current date and time
    var hours = now.getHours();
    var minutes = now.getMinutes();
    var seconds = now.getSeconds();

    // Pad with a zero if needed
    if (hours < 10) hours = "0" + hours;
    if (minutes < 10) minutes = "0" + minutes;
    if (seconds < 10) seconds = "0" + seconds;

    var timeString = hours + ':' + minutes + ':' + seconds;

    document.getElementById('clock').textContent = timeString;

    setTimeout(updateClock, 1000);
}

window.onload = updateClock;

const images = [
    '2022_honda_civic_1_1920x1080.jpg',
    '2021_honda_civic_type_r_9_1920x1080.jpg',
    '2024_nissan_gt-r_1_1920x1080.jpg',
    '2018_nissan_370z_heritage_edition_4_1920x1080.jpg',
    '2020-Mercedes-AMG-GT3---Front-Three-Quarter-201323-1920x1080.jpg',
    '2014_volvo_s60_1_1920x1080.jpg',
    '2023_audi_tt_rs_coupe_iconic_edition_1_1920x1080.jpg',
    '2022_audi_r8_us_1_1920x1080.jpg'
];

let currentImageIndex = 0;

function changeBackgroundImage() {
    document.body.style.backgroundImage = `url(/Images/Home/${images[currentImageIndex]})`;
    currentImageIndex = (currentImageIndex + 1) % images.length;
    setTimeout(changeBackgroundImage, 5000);
    console.log("Script is running");
}
changeBackgroundImage();




