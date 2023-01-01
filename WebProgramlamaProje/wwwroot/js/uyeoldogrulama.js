

var form = document.getElementById("form");
var SpanTekrarSifre = document.getElementById("SpanTekrarSifre");

form.addEventListener("submit", function (e) {

    var sifre = document.getElementById("Sifre").value;
    var inputTekrarSifre = document.getElementById("inputTekrarSifre").value;
    
    SpanTekrarSifre.innerHTML = "Şifreler Uyuşmamaktadır.";

    if (sifre != inputTekrarSifre) {

        alert("Şifreler Uyuşmamaktadır");
        
        e.preventDefault();
    } 
    
})

