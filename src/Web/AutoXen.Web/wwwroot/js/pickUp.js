// pickUpFunctionallity
var pickUpBtn = document.getElementById('PickUpFastAsPossible');
console.log(pickUpBtn)
var pickUpTime = document.getElementById('PickUpTime');

//on load
if (pickUpTime.value == '') {
    pickUpBtn.checked = true;
    DisableEnablePickUp(pickUpBtn, pickUpTime);
}
else {
    pickUpBtn.checked = false;
    DisableEnablePickUp(pickUpBtn, pickUpTime);
}

if (pickUpBtn != null) {
    pickUpBtn.addEventListener('click', (event) => {
        DisableEnablePickUp(pickUpBtn, pickUpTime);
    });
}

function DisableEnablePickUp(btn, pickUpTime) {
    if (btn.checked == true) {
        pickUpTime.value = null;
        pickUpTime.disabled = true;
    }
    else {
        pickUpTime.disabled = false;
    }
}