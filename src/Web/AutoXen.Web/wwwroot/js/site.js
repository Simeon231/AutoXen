// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var deleteBtn = document.getElementsByName("deleteBtn");
if (deleteBtn != null) {
    deleteBtn.forEach(x => x.addEventListener("click", () => {
        confirm("Are you sure you want to delete your " + x.getAttribute("property") + "?");
    }))
}

var dates = document.getElementsByName('date');

if (dates != null) {
    dates.forEach(x => {
        document.addEventListener('DOMContentLoaded', convertTimeToLocal(x));
    });
}

function convertTimeToLocal(time) {
    var fmt = 'DD/MM/YYYY HH:mm:ss';
    var result = moment.utc(time.textContent, fmt).local().format(fmt);
    time.textContent = result;
}

// TODO: Change js to functions