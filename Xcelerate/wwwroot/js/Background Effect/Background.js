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


        const size = Math.random() * 150 + 50;
        element.style.width = `${size}px`;
        element.style.height = `${size}px`;


        const posX = Math.random() * (window.innerWidth - size);
        const posY = Math.random() * (document.body.scrollHeight - size - 300); 
        element.style.left = `${posX}px`;
        element.style.top = `${posY}px`;


        const color = colors[Math.floor(Math.random() * colors.length)];
        element.style.backgroundColor = color;


        const duration = Math.random() * 150 + 150;
        element.style.animationDuration = `${duration}s`;

        document.body.appendChild(element);
    }


    for (let i = 0; i < 20; i++) { 
        createAbstractElement();
    }
});
