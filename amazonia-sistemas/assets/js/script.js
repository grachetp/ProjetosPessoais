window.addEventListener('scroll', myFunction);

function myFunction() {
  // Seleciona o elemento alvo
  var element = document.querySelector(".navbar");
  var element2 = document.querySelector(".img-logo");
  if (window.pageYOffset > 200) {
    // Ao descer 100px, realiza as modificações desejadas
    element.classList.add('scrolled');
    element2.classList.add('scrolled');

  } else {
    // Ao retornar ao topo da página, desfaz as modificações
    element.classList.remove('scrolled');
    element2.classList.remove('scrolled');
  }
}