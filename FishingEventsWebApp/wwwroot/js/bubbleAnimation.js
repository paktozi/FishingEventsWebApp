
document.addEventListener('DOMContentLoaded', function () {
    const bubbleContainer = document.createElement('div');
    bubbleContainer.className = 'bubble-container';
    document.body.appendChild(bubbleContainer);

    // Max bubbles limit
    const maxBubbles = 50; // Adjust to your preference

    // Function to create a bubble
    function createBubble() {
        if (bubbleContainer.childElementCount >= maxBubbles) {
            // If bubbles exceed maxBubbles, remove the oldest one
            bubbleContainer.removeChild(bubbleContainer.firstChild);
        }

        const bubble = document.createElement('div');
        bubble.className = 'bubble';

        // Randomize bubble size
        const size = Math.random() * 20 + 10;
        bubble.style.width = `${size}px`;
        bubble.style.height = `${size}px`;

        // Randomize bubble starting position and speed
        bubble.style.left = `${Math.random() * 100}vw`;
        bubble.style.animationDuration = `${5 + Math.random() * 10}s`;

        // Add bubble to the container
        bubbleContainer.appendChild(bubble);

        // Remove bubble once the animation ends
        bubble.addEventListener('animationend', function () {
            bubbleContainer.removeChild(bubble);
        });
    }

    // Generate bubbles at regular intervals
    setInterval(createBubble, 1500); // Adjust frequency as needed
});
