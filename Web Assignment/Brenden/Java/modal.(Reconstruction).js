function openModal() {
  document.getElementById('modal').style.display = "block";
}

function closeModal() {
  document.getElementById('modal').style.display = "none";
}

var slideIndex = 1;

function picture1() {
  document.getElementById('main').setAttribute('src', "../Image/Overlay Tulle Skirt2.jpg");
  document.getElementById('main').setAttribute('onclick',"openModal(); currentSlide(3);")
}

function picture2() {
  document.getElementById('main').setAttribute('src', "../Image/Overlay Tulle Skirt1.jpg");
  document.getElementById('main').setAttribute('onclick',"openModal(); currentSlide(2);")
}

function picture3() {
  document.getElementById('main').setAttribute('src', "../Image/Manokhi Leather Top1.jpg");
  document.getElementById('main').setAttribute('onclick',"openModal(); currentSlide(1);")
}

showSlides(slideIndex);

function plusSlides(n) {
  showSlides(slideIndex += n);
}

function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
  var i;
  var slides = document.getElementsByClassName("mySlides");
  var dots = document.getElementsByClassName("demo");
  var captionText = document.getElementById("caption");
  if (n > slides.length) { slideIndex = 1 }
  if (n < 1) { slideIndex = slides.length }
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex - 1].style.display = "block";
  dots[slideIndex - 1].className += " active";
}

let a = 0;
let b = 0;

function border1() {
  if (a == 0) {
    document.getElementById('knitA').setAttribute("style", "border : 3px solid rgb(173, 255, 118); border-radius: 20%;");
    a = 1;
  } else {
    document.getElementById('knitA').removeAttribute('style');
    a = 0;
  }
}

function border2() {
  if (a == 0) {
    document.getElementById('knitB').setAttribute("style", "border : 3px solid rgb(173, 255, 118); border-radius: 20%;");
    a = 1;
  } else {
    document.getElementById('knitB').removeAttribute('style');
    a = 0;
  }
}

function login(){
  window.location.href='../../Lim Wei Yang/Web/Log in.html';
}