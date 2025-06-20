// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


document.addEventListener("DOMContentLoaded", () => {
    const toggleButton = document.getElementById("menuToggle");
    const menuControls = document.querySelector(".mobile_layout .controls");

    toggleButton.addEventListener("click", () => {
        menuControls.classList.toggle("active");
        if (menuControls.classList.contains("active")) {
            toggleButton.innerText = "✖"; 
        } else {
            toggleButton.innerHTML = "&#9776;";
        }
    });
});


