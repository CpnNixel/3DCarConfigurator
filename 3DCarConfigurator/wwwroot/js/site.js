var colors = document.querySelectorAll(".color");
colors.forEach((element) => {
    element.onclick = function () {
        colors.forEach((elem) => {
            elem.className = "color"
        })
        element.className = "color selected"
    };
})