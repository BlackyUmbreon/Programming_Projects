function openModal4() {
    document.getElementById('myModal4').style.display = "block";
  }
  
  function closeModal4() {
    document.getElementById('myModal4').style.display = "none";
  }
  
  var slideIndex4 = 1;
  showSlides4(slideIndex4);
  
  function plusSlides4(n) {
    showSlides4(slideIndex4 += n);
  }
  
  function currentSlide4(n) {
    showSlides4(slideIndex4 = n);
  }
  
  function showSlides4(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides4");
    if (n > slides.length) { slideIndex4 = 1 }
    if (n < 1) { slideIndex4 = slides.length }
    for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
    }
  
    slides[slideIndex4 - 1].style.display = "block";
  
  }
  