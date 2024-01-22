const images = [
    '2023_porsche_911_gt3_rs.jpg',
    '2021_kia_sorento.jpg',
    '2021_peugeot_500.jpg',
    '2021-MINI-Countryman.jpg',
    '2022_lexus_lc_500h.jpg',
    '2022_skoda_fabia.jpg',
    '2022_volkswagen_golf_gti_us.jpg',
    '2023_ram_1500_trx_havoc_edition.jpg',
    '2024-McLaren-GTS.jpg',
    '2024-Mercedes-AMG-C-63-S-E-Performance-Sedan.jpg',
    '2025_subaru_forester.jpg'
    // Add more image URLs as needed
];

let currentImageIndex = 0;

function changeBackgroundImage() {
    document.body.style.backgroundImage = `url(/Images/Login/${images[currentImageIndex]})`;
    currentImageIndex = (currentImageIndex + 1) % images.length;
    setTimeout(changeBackgroundImage, 5000); // Change image every 5 seconds
    console.log("Script is running");
}
changeBackgroundImage();

// Start the slideshow