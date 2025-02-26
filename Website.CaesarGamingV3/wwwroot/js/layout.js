const toggler = document.querySelector(".btn");
toggler.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("collapsed");
});



//window.addEventListener("resize", adjustBackground);

//function adjustBackground() {
//    const body = document.body;
//    const viewportHeight = window.innerHeight;

//    // Adjust background position dynamically
//    body.style.backgroundPosition = `center calc(50% - ${(viewportHeight - body.offsetHeight) / 2}px)`;
//}

//// Trigger adjustment on page load
//adjustBackground();











