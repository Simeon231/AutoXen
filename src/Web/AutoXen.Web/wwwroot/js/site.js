// Delete confirmation
var deleteBtn = document.getElementsByName("deleteBtn");
if (deleteBtn != null) {
    deleteBtn.forEach(x => x.addEventListener("click", () => {
        confirm("Are you sure you want to delete your " + x.getAttribute("property") + "?");
    }))
}

var pickUpFastAsPossible = document.getElementById('FastAsPossible');

if (pickUpFastAsPossible != null) {
    pickUpFastAsPossible.addEventListener('click', (event) => {
        var pickUpTime = document.getElementsByName('PickUpTime')[0];

        if (pickUpFastAsPossible.checked == true) {
            pickUpTime.value = null;
            pickUpTime.disabled = true;
        }
        else {
            pickUpTime.disabled = false;
        }
    });
}

// Disable/Enable workshops on click
function EnableDisableWorkshops(btn) {
    const workshops = document.getElementById("workshops");
    const defaultOption = document.getElementById("hiddenValue");

    if (btn.checked == true) {
        workshops.disabled = true;
        workshops.value = defaultOption.value;
    }
    else {
        workshops.disabled = false;
    }
}

// convert datetime to datetime.now
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
    $('.js-example-basic-multiple').select2().select2({
        placeholder: 'Select an option',
        allowClear: true
    });
    $('#simpleSelect2').select2({
        placeholder: 'Select an option',
        allowClear: true,
    });
});

// Fetch
function GetAllServices() {
    fetch("api/WorkshopServices")
        .then(resources => resources.json())
        .then(data => {
            AddServicesToSelect(data);
        });
}

function GetWorkshopServices(workshop) {
    const id = workshop.selectedOptions[0].value;
    console.log(workshop.selectedOptions[0].value);
    fetch(`api/WorkshopServices/${id}`)
        .then(resources => resources.json())
        .then(data => {
            AddServicesToSelect(data);
        });
}

function AddServicesToSelect(data) {
    const select = document.getElementById("ServiceIds");
    select.innerHTML = null;
    data.forEach(x => {
        var option = document.createElement("option");
        if (x.price == null) {
            option.text = x.name;
            option.value = x.id;
        }
        else {
            option.text = `${x.serviceName} - ${x.price}$`
            option.value = x.serviceId;
        }

        console.log(option);
        select.add(option);
    })


}

// TODO: Change js to functions