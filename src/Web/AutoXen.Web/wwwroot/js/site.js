// My
var deleteBtn = document.getElementsByName("deleteBtn");
if (deleteBtn != null) {
    deleteBtn.forEach(x => x.addEventListener("click", () => {
        confirm("Are you sure you want to delete your " + x.getAttribute("property") + "?");
    }))
}

// convert datetime to datetime.now
var dates = document.getElementsByName('date');

if (dates != null) {
    dates.forEach(x => {
        document.addEventListener('DOMContentLoaded', convertTimeToLocal(x));
    });
}

//moment.js
function convertTimeToLocal(time) {
    var fmt = 'DD/MM/YYYY HH:mm:ss';
    var result = moment.utc(time.textContent, fmt).local().format(fmt);
    time.textContent = result;
}

//Select2
$(document).ready(function () {
    $('.js-example-basic-multiple').select2();
});

// TODO: Change js to functions