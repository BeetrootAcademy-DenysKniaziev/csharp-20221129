const photo = document.getElementById("photo");
const description = document.getElementById("description");
const prevButton = document.getElementById("prev-button");
const nextButton = document.getElementById("next-button");

const photos = [
    {
        src: "images/IMG_1479.JPG",
        alt: "Fishing",
        description: "Fact 1: I love fishing"
    },
    {
        src: "images/IMG_3761.jpg",
        alt: "Snowbording",
        description: "Fact 2: I`m snowboarding"
    },
    {
        src: "images/IMG-1a340d0af1cdca4a3a5bf49240540896-V.jpg",
        alt: "Paliontology",
        description: "Fact 3: I love traveling and collect archaeology and paleontology items"
    }
];

let currentPhoto = 0;

function showPhoto() {
    photo.src = photos[currentPhoto].src;
    photo.alt = photos[currentPhoto].alt;
    description.textContent = photos[currentPhoto].description;
}

prevButton.addEventListener("click", () => {
    currentPhoto--;
    if (currentPhoto < 0) {
        currentPhoto = photos.length - 1;
    }
    showPhoto();
});

nextButton.addEventListener("click", () => {
    currentPhoto++;
    if (currentPhoto >= photos.length) {
        currentPhoto = 0;
    }
    showPhoto();
});

showPhoto();