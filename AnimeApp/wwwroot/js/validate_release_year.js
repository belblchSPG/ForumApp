function validateReleaseYear() {
    var releaseYearInput = document.getElementById("ReleaseYear");
    var releaseYear = parseInt(releaseYearInput.value);

    if (releaseYear < 1901 || releaseYear > 2100) {
        // Показать ошибку
        var errorSpan = releaseYearInput.nextElementSibling; // Получаем следующий элемент после input
        errorSpan.innerText = "Год должен быть в диапазоне 1901-2100";

        // Остановить отправку формы
        event.preventDefault();
    }
}
