function openModal3() {
    document.getElementById('myModal3').style.display = "block";
  }
  
  function closeModal3() {
    document.getElementById('myModal3').style.display = "none";
  }
  
  var slideIndex3 = 1;
  showSlides3(slideIndex3);
  
  function plusSlides3(n) {
    showSlides3(slideIndex3 += n);
  }
  
  function currentSlide3(n) {
    showSlides3(slideIndex3 = n);
  }
  
  function showSlides3(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides3");
    if (n > slides.length) { slideIndex3 = 1 }
    if (n < 1) { slideIndex3 = slides.length }
    for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
    }
  
    slides[slideIndex3 - 1].style.display = "block";
  
  }
  