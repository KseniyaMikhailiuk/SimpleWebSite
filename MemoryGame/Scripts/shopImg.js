var modal = document.getElementById('myModal');

var modalImg = document.getElementById("img01");
var description = document.getElementById("description");

function showModal(imgId) {
    var img = document.getElementById(imgId);
    modal.style.display = "inline-flex";
    modalImg.src = img.src;
    var container = img.parentElement;
    var collection = container.children;
    
    if (imgId == 'createItem') {
        var createForm = document.getElementById("createForm");
        createForm.style.display = "inline-flex";
    }
    else {
        description.innerHTML = img.alt;
    }
    //var button = document.createElement('input');
    //button.setAttribute("type", "submit");
    //button.value = "В корзину";
    //description.appendChild(button);
}


var span = document.getElementsByClassName("close")[0];

span.onclick = function () {
    modal.style.display = "none";
}