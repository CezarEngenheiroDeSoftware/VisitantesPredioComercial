// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// EVENTO DE TOOLTIP //


document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".eventTool").forEach(function (botao) {

        const tooltipText = botao.parentElement.querySelector(".tooltipCustom");
        botao.addEventListener("mouseover", function () {
            tooltipText.style.display = "block";
        });
        botao.addEventListener("mouseout", function () {
            tooltipText.style.display = "none";
        });
    });

    document.querySelectorAll(".eventToolEditar").forEach(function (botao) {

        const tooltipText = botao.parentElement.querySelector(".tooltipCustomEdit");
        botao.addEventListener("mouseover", function () {
            tooltipText.style.display = "block";
        });
        botao.addEventListener("mouseout", function () {
            tooltipText.style.display = "none";
        });
    });
});
const botaofechar = document.querySelector("._BotaoMensagemFechar");
const mensagemwarning = document.querySelector(".MensagenWarning");
botaofechar.addEventListener("click", function () {
    mensagemwarning.style.display = "none";
});