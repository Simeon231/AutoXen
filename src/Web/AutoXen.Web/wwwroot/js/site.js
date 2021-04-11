// Delete confirmation
var deleteBtn = document.getElementsByName("deleteBtn");
if (deleteBtn != null) {
    deleteBtn.forEach(x => x.addEventListener("click", () => {
        confirm("Are you sure you want to delete your " + x.getAttribute("property") + "?");
    }))
}

// convert datetime.utc to user's datetime.now
var dates = document.getElementsByClassName('momentTime');
var inputDates = document.getElementsByClassName('inputMomentTime');

if (dates != null) {
    for (var i = 0; i < dates.length; i++) {
        document.addEventListener('DOMContentLoaded', convertTimeToLocal(dates[i]));
    }
}

if (inputDates != null) {
    for (var i = 0; i < inputDates.length; i++) {
        document.addEventListener('DOMContentLoaded', convertTimeToLocalForInput(inputDates[i]));
    }
}

// moment.js
function convertTimeToLocal(time) {
    const fmt = 'L LTS';
    //console.log(time.textContent);
    let result = moment.utc(time.textContent, "DD/MM/YYYY hh:mm:ss A").local().format(fmt);
    console.log(result);
    if (result == "Invalid date") {
        result = moment.utc(time.textContent, "MM/DD/YYYY hh:mm:ss A").local().format(fmt);
    }

    time.textContent = result;
    //console.log('')
}

function convertTimeToLocalForInput(time) {
    const fmt = 'YYYY-MM-DDTHH:mm:ss.sss';

    result = moment.utc(time.value, fmt).local().format(fmt);

    time.value = result;
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