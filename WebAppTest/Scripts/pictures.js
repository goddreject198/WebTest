const images = document.querySelectorAll('.image');
images.forEach(image => {
    image.addEventListener('click', () => {
        const paragraph = image.querySelector('p');
        const img = image.querySelector('img');
        alert(paragraph.innerText + ": " + img.src);
    });
});
