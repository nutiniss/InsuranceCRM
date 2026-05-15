// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('.stat-card-link[data-url]').forEach((card) => {
        const navigateToCardUrl = () => {
            window.location.href = card.dataset.url;
        };

        card.addEventListener('click', (event) => {
            if (event.target.closest('a, button')) {
                return;
            }

            navigateToCardUrl();
        });

        card.addEventListener('keydown', (event) => {
            if (event.key !== 'Enter' && event.key !== ' ') {
                return;
            }

            event.preventDefault();
            navigateToCardUrl();
        });
    });
});
