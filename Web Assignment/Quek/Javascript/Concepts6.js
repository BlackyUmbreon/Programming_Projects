function openModal6() {
    document.getElementById('myModal6').style.display = "block";
  }
  
  function closeModal6() {
    document.getElementById('myModal6').style.display = "none";
  }
  
  var slideIndex6 = 1;
  showSlides6(slideIndex6);
  
  function plusSlides6(n) {
    showSlides6(slideIndex6 += n);
  }
  
  function currentSlide6(n) {
    showSlides6(slideIndex6 = n);
  }
  
  function showSlides6(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides6");
    if (n > slides.length) { slideIndex6 = 1 }
    if (n < 1) { slideIndex6 = slides.length }
    for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
    }
  
    slides[slideIndex6 - 1].style.display = "block";
  
  }
  