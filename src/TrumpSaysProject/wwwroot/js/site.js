// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.addEventListener("load", function(){
  document.querySelector("body").addEventListener("click", function (e) {
    const observer = new MutationObserver(function () {
      console.log("callback that runs when observer is triggered");
      // document.querySelector(".lead").style.animation = "none";
      // document.querySelector(".lead").style.animation = "fadeIn 1s linear";
      document.querySelector(".card-body").classList.add("fadeIn");
      // document.querySelector(".lead").classList.remove("fadeIn");
      setTimeout(() => document.querySelector(".card-body").classList.remove("fadeIn"), 500);
      // setTimeout(() => document.querySelector(".lead").classList.add("fadeIn"), 500);
    });
    observer.observe(document.querySelector(".card-body"), { characterData: true, subtree: true, childList: true });
  }, { once: true });
});
