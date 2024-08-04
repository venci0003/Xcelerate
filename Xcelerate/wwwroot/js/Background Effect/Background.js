document.addEventListener("DOMContentLoaded", function () {
    const colors = [
        "rgba(255, 99, 71, 0.6)",
        "rgba(135, 206, 235, 0.6)",
        "rgba(50, 205, 50, 0.6)",
        "rgba(218, 112, 214, 0.6)",
        "rgba(255, 215, 0, 0.6)"
    ];

    function createAbstractElement() {
        const element = document.createElement("div");
        element.className = "abstract-element";

        // Set random size, position, color, and animation duration
        const size = Math.random() * 150 + 50; // Size between 50px and 200px
        element.style.width = `${size}px`;
        element.style.height = `${size}px`;

        // Set random position, accounting for the size of the element
        const posX = Math.random() * (window.innerWidth - size);
        const posY = Math.random() * (document.body.scrollHeight - size - 300); // Using document.body.scrollHeight for full page height
        element.style.left = `${posX}px`;
        element.style.top = `${posY}px`;

        // Choose a random color from the array
        const color = colors[Math.floor(Math.random() * colors.length)];
        element.style.backgroundColor = color;

        // Set a random animation duration
        const duration = Math.random() * 150 + 150; // Duration between 30s and 60s
        element.style.animationDuration = `${duration}s`;

        document.body.appendChild(element);
    }

    // Create a number of abstract elements
    for (let i = 0; i < 20; i++) { // Increase the number of elements
        createAbstractElement();
    }
});
