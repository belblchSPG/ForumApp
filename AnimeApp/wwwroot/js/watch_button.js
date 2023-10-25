document.addEventListener('DOMContentLoaded', function () {

    var watchButton = document.getElementById('watchButton');
    var animeId = watchButton.getAttribute('data-anime-id');
    // Функция для проверки статуса аниме

    function checkAnimeStatus() {

        debugger;
        fetch(`/animes/check_user_anime/${animeId}`)
            .then(response => response.json())
            .then(data => {
                if (data.watched == true) {
                    console.log("anime is watched");

                    watchButton.textContent = 'Просмотрено';
                    watchButton.classList.add('watched');
                }
                else {
                    console.log("anime isn`t watched");
                }
            })

    }
    checkAnimeStatus();
});

watchButton.addEventListener('click', function () {

    debugger;

    var watchButton = document.getElementById('watchButton');
    var animeId = watchButton.getAttribute('data-anime-id');

    var animeId = watchButton.getAttribute('data-anime-id')

    fetch(`/animes/check_user_anime/${animeId}`)
        .then(response => response.json())
        .then(data => {
            if (data.watched) {
                try {
                    debugger;
                    fetch(`/animes/remove_anime_from_user/${animeId}`)
                        .then(second => second.json())
                        .then(data => {
                            if (data.result) {
                                console.info("Anime was succecfully removed.");

                                watchButton.classList.remove('watched');
                                watchButton.textContent = 'Буду смотреть';
                            }
                            else {
                                console.warn("Server couldn`t remove anime.");
                            }
                        })
                }
                catch (e) {
                    console.warn("Something went wrong whole removing anime.");
                    console.error("Error: " + e);
                }
            }
            else {
                try {
                    fetch(`/animes/add_anime_to_user/${animeId}`)
                        .then(response => response.json())
                        .then(data => {
                            if (data.result) {
                                console.info("Anime was succecfully added.");
                                watchButton.classList.add('watched');
                                watchButton.textContent = 'Просмотрено';
                            }
                            else {
                                console.warn("Server couldn`t add anime.");
                            }
                        })
                }
                catch (e) {
                    console.warn("Something went wrong while adding anime.");
                    console.error("Error: " + e);
                }
            }
        })
});