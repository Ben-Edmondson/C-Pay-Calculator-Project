function AlertSuccess() {
    var x = document.getElementByID("alertDeleteSuccess");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}