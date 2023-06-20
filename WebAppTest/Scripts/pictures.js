const images = document.querySelectorAll('.image');
images.forEach(image => {
    image.addEventListener('click', () => {
        const paragraph = image.querySelector('p');
        const img = image.querySelector('img');
        //alert(paragraph.innerText + ": " + img.src);
        //document.querySelector(".listPictures").classList.add("close");
        document.querySelector(".container").classList.add("active");
        document.querySelector(".listPictures").classList.add("unactive");
        document.querySelector(".picTag").src = img.src;
        document.querySelector(".details").innerHTML = paragraph.innerText;
    });
});

document.querySelector("#closebtn").addEventListener("click", function () {
    document.querySelector(".container").classList.remove("active");
    document.querySelector(".listPictures").classList.remove("unactive");
})

document.querySelector("#prepic").addEventListener("click", function () {
    alert("Pre pic");
})

document.querySelector("#nextpic").addEventListener("click", function () {
    alert("Next pic");
})