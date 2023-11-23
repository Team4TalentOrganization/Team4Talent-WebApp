// Tinder.razor.js

window.tinderSwipe = (container, isSwipeRight) => {
    if (!container) return;

    let offsetX = isSwipeRight ? -container.clientWidth : container.clientWidth;

    container.style.transition = "transform 0.3s ease-in-out";
    container.style.transform = `translateX(${offsetX}px)`;

    setTimeout(() => {
        container.style.transition = "none";
        container.style.transform = "translateX(0)";
    }, 300);
};
