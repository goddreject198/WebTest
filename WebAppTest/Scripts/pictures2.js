console.clear();
const images = document.querySelectorAll('.image');
const { gsap, imagesLoaded } = window;

const buttons = {
    prev: document.querySelector(".btn--left"),
    next: document.querySelector(".btn--right"),
};
const cardsContainerEl = document.querySelector(".cards__wrapper");
const appBgContainerEl = document.querySelector(".app__bg");


const cardInfosContainerEl = document.querySelector(".info__wrapper");

buttons.next.addEventListener("click", () => swapCards("right"));

buttons.prev.addEventListener("click", () => swapCards("left"));

function swapCards(direction) {
    const currentCardEl = cardsContainerEl.querySelector(".current--card");
    const previousCardEl = cardsContainerEl.querySelector(".previous--card");
    const nextCardEl = cardsContainerEl.querySelector(".next--card");

    const currentBgImageEl = appBgContainerEl.querySelector(".current--image");
    const previousBgImageEl = appBgContainerEl.querySelector(".previous--image");
    const nextBgImageEl = appBgContainerEl.querySelector(".next--image");

    let current_id = Number(document.querySelector("#piciddt").innerHTML);
    changeInfo(direction);
    swapCardsClass();

    removeCardEvents(currentCardEl);

    function swapCardsClass() {
        currentCardEl.classList.remove("current--card");
        previousCardEl.classList.remove("previous--card");
        nextCardEl.classList.remove("next--card");

        currentBgImageEl.classList.remove("current--image");
        previousBgImageEl.classList.remove("previous--image");
        nextBgImageEl.classList.remove("next--image");

        currentCardEl.style.zIndex = "50";
        currentBgImageEl.style.zIndex = "-2";

        if (direction === "right") {
            previousCardEl.style.zIndex = "20";
            nextCardEl.style.zIndex = "30";

            nextBgImageEl.style.zIndex = "-1";

            if (current_id + 1 == images.length) {
                document.querySelector("#piciddt").innerHTML = images.length;
                previousCardEl.querySelector(".card__image").querySelector(".card__image__dt").src = images[0].querySelector('img').src;
                previousBgImageEl.querySelector(".app_bg_image_dt").src = images[0].querySelector('img').src;
            } else if (current_id == images.length) {
                document.querySelector("#piciddt").innerHTML = 1;
                previousCardEl.querySelector(".card__image").querySelector(".card__image__dt").src = images[1].querySelector('img').src;
                previousBgImageEl.querySelector(".app_bg_image_dt").src = images[1].querySelector('img').src;
            }
            else {
                document.querySelector("#piciddt").innerHTML = current_id + 1;
                previousCardEl.querySelector(".card__image").querySelector(".card__image__dt").src = images[current_id + 1].querySelector('img').src;
                previousBgImageEl.querySelector(".app_bg_image_dt").src = images[current_id + 1].querySelector('img').src;
            }

            currentCardEl.classList.add("previous--card");
            previousCardEl.classList.add("next--card");
            nextCardEl.classList.add("current--card");

            currentBgImageEl.classList.add("previous--image");
            previousBgImageEl.classList.add("next--image");
            nextBgImageEl.classList.add("current--image");
        } else if (direction === "left") {
            previousCardEl.style.zIndex = "30";
            nextCardEl.style.zIndex = "20";

            previousBgImageEl.style.zIndex = "-1";

            if (current_id == 2) {
                document.querySelector("#piciddt").innerHTML = 1;
                nextCardEl.querySelector(".card__image").querySelector(".card__image__dt").src = images[images.length - 1].querySelector('img').src;
                nextBgImageEl.querySelector(".app_bg_image_dt").src = images[images.length - 1].querySelector('img').src;
            } else if (current_id == 1) {
                document.querySelector("#piciddt").innerHTML = images.length;
                nextCardEl.querySelector(".card__image").querySelector(".card__image__dt").src = images[images.length - 2].querySelector('img').src;
                nextBgImageEl.querySelector(".app_bg_image_dt").src = images[images.length - 2].querySelector('img').src;
            }
            else {
                document.querySelector("#piciddt").innerHTML = current_id - 1;
                nextCardEl.querySelector(".card__image").querySelector(".card__image__dt").src = images[current_id - 3].querySelector('img').src;
                nextBgImageEl.querySelector(".app_bg_image_dt").src = images[current_id - 3].querySelector('img').src;
            }

            currentCardEl.classList.add("next--card");
            previousCardEl.classList.add("current--card");
            nextCardEl.classList.add("previous--card");

            currentBgImageEl.classList.add("next--image");
            previousBgImageEl.classList.add("current--image");
            nextBgImageEl.classList.add("previous--image");
        }
    }
}

function changeInfo(direction) {
    let currentInfoEl = cardInfosContainerEl.querySelector(".current--info");
    let previousInfoEl = cardInfosContainerEl.querySelector(".previous--info");
    let nextInfoEl = cardInfosContainerEl.querySelector(".next--info");

    gsap.timeline()
        .to([buttons.prev, buttons.next], {
            duration: 0.2,
            opacity: 0.5,
            pointerEvents: "none",
        })
        .to(
            currentInfoEl.querySelectorAll(".text"),
            {
                duration: 0.4,
                stagger: 0.1,
                translateY: "-120px",
                opacity: 0,
            },
            "-="
        )
        .call(() => {
            swapInfosClass(direction);
        })
        .call(() => initCardEvents())
        .fromTo(
            direction === "right"
                ? nextInfoEl.querySelectorAll(".text")
                : previousInfoEl.querySelectorAll(".text"),
            {
                opacity: 0,
                translateY: "40px",
            },
            {
                duration: 0.4,
                stagger: 0.1,
                translateY: "0px",
                opacity: 1,
            }
        )
        .to([buttons.prev, buttons.next], {
            duration: 0.2,
            opacity: 1,
            pointerEvents: "all",
        });

    function swapInfosClass() {
        currentInfoEl.classList.remove("current--info");
        previousInfoEl.classList.remove("previous--info");
        nextInfoEl.classList.remove("next--info");

        if (direction === "right") {
            currentInfoEl.classList.add("previous--info");
            nextInfoEl.classList.add("current--info");
            previousInfoEl.classList.add("next--info");
        } else if (direction === "left") {
            currentInfoEl.classList.add("next--info");
            nextInfoEl.classList.add("previous--info");
            previousInfoEl.classList.add("current--info");
        }
    }
}

function updateCard(e) {
    const card = e.currentTarget;
    const box = card.getBoundingClientRect();
    const centerPosition = {
        x: box.left + box.width / 2,
        y: box.top + box.height / 2,
    };
    let angle = Math.atan2(e.pageX - centerPosition.x, 0) * (35 / Math.PI);
    gsap.set(card, {
        "--current-card-rotation-offset": `${angle}deg`,
    });
    const currentInfoEl = cardInfosContainerEl.querySelector(".current--info");
    gsap.set(currentInfoEl, {
        rotateY: `${angle}deg`,
    });
}

function resetCardTransforms(e) {
    const card = e.currentTarget;
    const currentInfoEl = cardInfosContainerEl.querySelector(".current--info");
    gsap.set(card, {
        "--current-card-rotation-offset": 0,
    });
    gsap.set(currentInfoEl, {
        rotateY: 0,
    });
}

function initCardEvents() {
    const currentCardEl = cardsContainerEl.querySelector(".current--card");
    currentCardEl.addEventListener("pointermove", updateCard);
    currentCardEl.addEventListener("pointerout", (e) => {
        resetCardTransforms(e);
    });
}

initCardEvents();

function removeCardEvents(card) {
    card.removeEventListener("pointermove", updateCard);
}

function init() {

    let tl = gsap.timeline();

    tl.to(cardsContainerEl.children, {
        delay: 0.15,
        duration: 0.5,
        stagger: {
            ease: "power4.inOut",
            from: "right",
            amount: 0.1,
        },
        "--card-translateY-offset": "0%",
    })
        .to(cardInfosContainerEl.querySelector(".current--info").querySelectorAll(".text"), {
            delay: 0.5,
            duration: 0.4,
            stagger: 0.1,
            opacity: 1,
            translateY: 0,
        })
        .to(
            [buttons.prev, buttons.next],
            {
                duration: 0.4,
                opacity: 1,
                pointerEvents: "all",
            },
            "-=0.4"
        );
}

const waitForImages = () => {
    const images = [...document.querySelectorAll("img")];
    const totalImages = images.length;
    let loadedImages = 0;
    const loaderEl = document.querySelector(".loader span");

    gsap.set(cardsContainerEl.children, {
        "--card-translateY-offset": "100vh",
    });
    gsap.set(cardInfosContainerEl.querySelector(".current--info").querySelectorAll(".text"), {
        translateY: "40px",
        opacity: 0,
    });
    gsap.set([buttons.prev, buttons.next], {
        pointerEvents: "none",
        opacity: "0",
    });

    images.forEach((image) => {
        imagesLoaded(image, (instance) => {
            if (instance.isComplete) {
                loadedImages++;
                let loadProgress = loadedImages / totalImages;

                gsap.to(loaderEl, {
                    duration: 1,
                    scaleX: loadProgress,
                    backgroundColor: `hsl(${loadProgress * 120}, 100%, 50%`,
                });

                if (totalImages == loadedImages) {
                    gsap.timeline()
                        .to(".loading__wrapper", {
                            duration: 0.8,
                            opacity: 0,
                            pointerEvents: "none",
                        })
                        .call(() => init());
                }
            }
        });
    });
};

waitForImages();




images.forEach(image => {
    image.addEventListener('click', () => {
        const paragraph = image.querySelector('#image');
        const img = image.querySelector('img');
        const picid = image.querySelector('#picid');
        document.querySelector(".picDetails").classList.add("active");
        document.querySelector(".listPictures").classList.add("unactive");
        document.querySelector("#piciddt").innerHTML = picid.innerText;
        document.querySelector("#img__card__cur").src = img.src;
        if (Number(picid.innerText) == 1) {
            document.querySelector("#img__card__pre").src = images[images.length - 1].querySelector('img').src;
            document.querySelector("#img__card__next").src = images[Number(picid.innerText)].querySelector('img').src;
        } else if (Number(picid.innerText) == images.length) {
            document.querySelector("#img__card__pre").src = images[Number(picid.innerText) - 2].querySelector('img').src;
            document.querySelector("#img__card__next").src = images[0].querySelector('img').src;
        } else {
            document.querySelector("#img__card__pre").src = images[Number(picid.innerHTML) - 2].querySelector('img').src;
            document.querySelector("#img__card__next").src = images[Number(picid.innerHTML)].querySelector('img').src;
        }
    });
});

document.querySelector("#closebtn").addEventListener("click", function () {
    let previousCardEl = cardsContainerEl.querySelector(".divcard1");
    let currentCardEl = cardsContainerEl.querySelector(".divcard2");
    let nextCardEl = cardsContainerEl.querySelector(".divcard3");
    let previousBgImageEl = appBgContainerEl.querySelector(".divbg1");
    let currentBgImageEl = appBgContainerEl.querySelector(".divbg2");
    let nextBgImageEl = appBgContainerEl.querySelector(".divbg3");

    document.querySelector(".picDetails").classList.remove("active");
    document.querySelector(".listPictures").classList.remove("unactive");

    if (previousCardEl) {
        previousCardEl.classList = [];
        previousCardEl.classList.add("div1");
        previousCardEl.classList.add("card");
        previousCardEl.classList.add("previous--card");
    }

    if (currentCardEl) {
        currentCardEl.classList = [];
        currentCardEl.classList.add("div2");
        currentCardEl.classList.add("card");
        currentCardEl.classList.add("current--card");
    }

    if (nextCardEl) {
        nextCardEl.classList = [];
        nextCardEl.classList.add("div3");
        nextCardEl.classList.add("card");
        nextCardEl.classList.add("next--card");
    }


    if (previousBgImageEl) {
        previousBgImageEl.classList = [];
        previousBgImageEl.classList.add("divbg1");
        previousBgImageEl.classList.add("app__bg__image");
        previousBgImageEl.classList.add("previous--image");
    }
    if (currentBgImageEl) {
        currentBgImageEl.classList = [];
        currentBgImageEl.classList.add("divbg2");
        currentBgImageEl.classList.add("app__bg__image");
        currentBgImageEl.classList.add("current--image");
    }

    if (nextBgImageEl) {
        nextBgImageEl.classList = [];
        nextBgImageEl.classList.add("divbg3");
        nextBgImageEl.classList.add("app__bg__image");
        nextBgImageEl.classList.add("next--image");
    }
})