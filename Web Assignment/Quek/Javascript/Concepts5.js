function openModal5() {
    document.getElementById('myModal5').style.display = "block";
  }
  
  function closeModal5() {
    document.getElementById('myModal5').style.display = "none";
  }
  
  var slideIndex5 = 1;
  showSlides5(slideIndex5);
  
  function plusSlides5(n) {
    showSlides5(slideIndex5 += n);
  }
  
  function currentSlide5(n) {
    showSlides5(slideIndex5 = n);
  }
  
  function showSlides5(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides5");
    if (n > slides.length) { slideIndex5 = 1 }
    if (n < 1) { slideIndex5 = slides.length }
    for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
    }
  
    slides[slideIndex5 - 1].style.display = "block";
  
  }
  