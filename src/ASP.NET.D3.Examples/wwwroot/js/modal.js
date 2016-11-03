// Get the modal
var modal = document.getElementById('myModal');

// Define funtion to close modal
var openModal = function () {
    modal.style.display = "block";
}

// Define function to close modal.
var closeModal = function () {
    modal.style.display = "none";
}

var saveModal = function () {
    // TODO ajax update the data here or trigger a post?
    closeModal();
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target === modal) {
        closeModal();
    }
}