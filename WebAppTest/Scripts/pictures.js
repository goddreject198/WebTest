const images = document.querySelectorAll('.image');
images.forEach(image => {
    image.addEventListener('click', () => {
        const paragraph = image.querySelector('#image');
        const img = image.querySelector('img');
        const picid = image.querySelector('#picid');
        //alert(paragraph.innerText + ": " + img.src);
        //document.querySelector(".listPictures").classList.add("close");
        document.querySelector(".container").classList.add("active");
        document.querySelector(".listPictures").classList.add("unactive");
        document.querySelector(".picTag").src = img.src;
        document.querySelector(".details").innerHTML = paragraph.innerText;
        document.querySelector("#piciddt").innerHTML = picid.innerText;
    });
});

document.querySelector("#closebtn").addEventListener("click", function () {
    document.querySelector(".container").classList.remove("active");
    document.querySelector(".listPictures").classList.remove("unactive");
})

document.querySelector("#prepic").addEventListener("click", function () {
    let current_id = Number(document.querySelector("#piciddt").innerHTML);
    if (current_id == 1) {
        return;
    }
    else {
        document.querySelector(".picTag").src = images[current_id - 2].querySelector('img').src;
        document.querySelector(".details").innerHTML = images[current_id - 2].querySelector('#image').innerText;
        document.querySelector("#piciddt").innerHTML = current_id - 1;
    }
})

document.querySelector("#nextpic").addEventListener("click", function () {
    let current_id = Number(document.querySelector("#piciddt").innerHTML);
    if (current_id == 8) {
        return;
    }
    else {
        document.querySelector(".picTag").src = images[current_id].querySelector('img').src;
        document.querySelector(".details").innerHTML = images[current_id].querySelector('#image').innerText;
        document.querySelector("#piciddt").innerHTML = current_id + 1;
    }
})