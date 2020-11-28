// Disable/Enable workshops on click

const workshopBtn = document.getElementById('AdminChooseWorkshop');
const workshop = document.getElementById("WorkshopId");
const defaultOption = document.getElementById("hiddenValue");

//on load
if (workshop.value == defaultOption.value) {
    workshopBtn.checked = true;
    EnableDisableWorkshops(workshopBtn);
}
else {
    workshopBtn.checked = false;
    EnableDisableWorkshops(workshopBtn);
}

function EnableDisableWorkshops(btn) {
    if (btn.checked == true) {
        workshop.disabled = true;
        workshop.value = defaultOption.value;
    }
    else {
        workshop.disabled = false;
    }
}

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
    fetch(`api/WorkshopServices/${id}`)
        .then(resources => resources.json())
        .then(data => {
            AddServicesToSelect(data);
        });
}

function AddServicesToSelect(data) {
    const select = document.getElementById("Ids");
    select.innerHTML = null;
    data.forEach(x => {
        var option = document.createElement("option");
        if (x.price == null) {
            option.text = x.name;
            option.value = x.id;
        }
        else {
            option.text = `${x.serviceName} - ${x.price}$`
            option.value = x.id;
        }

        select.add(option);
    })
}