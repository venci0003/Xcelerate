const images = [
    '2015_ford_mustang_eu.jpg',
    '2019_nissan_370z_heritage_edition.jpg',
    '2019_renault_megane_rs_trophy.jpg',
    '2019-Mazda-MX-5-Roadster.jpg',
    '2019-Mitsubishi-Engelberg-Tourer.jpg',
    '2020_dodge_challenger_srt_super_stock.jpg',
    '2020_skoda_superb_scout.jpg',
    '2020_tesla_roadster.jpg',
    '2024_audi_q8_e-tron_dakar_edition.jpg',
    '2024_bmw_x5_m_competition.jpg',
    '2024_lotus_emira_i4.jpg'
    // Add more image URLs as needed
];

let currentImageIndex = 0;

function changeBackgroundImage() {
    document.body.style.backgroundImage = `url(/Images/Register/${images[currentImageIndex]})`;
    currentImageIndex = (currentImageIndex + 1) % images.length;
    setTimeout(changeBackgroundImage, 5000); // Change image every 5 seconds
    console.log("Script is running");
}
changeBackgroundImage();

// Start the slideshow