// Select all audio players
const audioPlayers = document.querySelectorAll('.audioPlayer');

// Add event listeners to each audio player
audioPlayers.forEach(player => {
    player.addEventListener('play', () => {
        // Pause all other players when a new one starts
        audioPlayers.forEach(otherPlayer => {
            if (otherPlayer !== player) {
                otherPlayer.pause();
            }
        });
    });
});