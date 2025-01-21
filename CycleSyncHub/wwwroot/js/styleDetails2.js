document.addEventListener("DOMContentLoaded", function () {
    const infosDiv = document.getElementById("infos");
    const encodedName = infosDiv.getAttribute("data-encoded-name");

    // Przykładowa logika: Pobranie dodatkowych informacji na podstawie encodedName
    if (encodedName) {
        fetch(`/api/bikes/${encodedName}/infos`)
            .then(response => response.json())
            .then(data => {
                const infoContent = document.createElement("div");
                infoContent.textContent = `Additional Info: ${data.info}`;
                infosDiv.appendChild(infoContent);
            })
            .catch(error => console.error('Error fetching additional info:', error));
    }
});