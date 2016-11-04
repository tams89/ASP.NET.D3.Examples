// Get the modal
var modal = document.getElementById('myModal');

// Define funtion to close modal
var openModal = function (data) {
    document.getElementById("id").value = data.id;
    document.getElementById("data").value = data.name;
    modal.style.display = "block";
}

// Define function to close modal.
var closeModal = function () {
    modal.style.display = "none";
    update();
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target === modal) {
        closeModal();
    }
}