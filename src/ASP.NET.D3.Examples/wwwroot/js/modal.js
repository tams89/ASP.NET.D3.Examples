// Get the modal
var modal = document.getElementById('myModal');

// Define funtion to close modal
var openModal = function (data) {
    document.getElementById("id").value = data.id;
    document.getElementById("data").value = data.name;
    document.getElementById("type").value = data.type;
    modal.style.display = "block";
}

// Define function to close modal.
var closeModal = function () {
    modal.style.display = "none";
    update(); // TODO refactor modal is tightly bound to this tree function.
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target === modal) {
        closeModal();
    }
}