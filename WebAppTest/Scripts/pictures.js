const images = document.querySelectorAll('.image');
images.forEach(image => {
    image.addEventListener('click', () => {
        const paragraph = image.querySelector('p');
        const img = image.querySelector('img');
        //alert(paragraph.innerText + ": " + img.src);
        //document.querySelector(".listPictures").classList.add("close");
        document.querySelector(".picDetails").classList.add("active");
        document.querySelector(".listPictures").classList.add("unactive");
        document.querySelector(".picTag").src = img.src;
    });
});
