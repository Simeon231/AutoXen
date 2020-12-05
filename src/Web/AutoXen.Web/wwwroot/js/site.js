// Delete confirmation
var deleteBtn = document.getElementsByName("deleteBtn");
if (deleteBtn != null) {
    deleteBtn.forEach(x => x.addEventListener("click", () => {
        confirm("Are you sure you want to delete your " + x.getAttribute("property") + "?");
    }))
}

// convert datetime.utc to user's datetime.now
var dates = document.getElementsByName('date');

if (dates != null) {
    dates.forEach(x => {
        document.addEventListener('DOMContentLoaded', convertTimeToLocal(x));
    });
}

// moment.js
function convertTimeToLocal(time) {
    const fmt = 'DD/MM/YYYY HH:mm:ss';
    const result = moment.utc(time.textContent, fmt).local().format(fmt);
    time.textContent = result;
}

// Select2
$(document).ready(function () {
    $('.js-select-multiple').select2().select2({
        placeholder: 'Select an option',
        allowClear: true
    });
    $('#simpleSelect2').select2({
        placeholder: 'Select an option',
        allowClear: true,
    });
});


// TODO: Change js to functions