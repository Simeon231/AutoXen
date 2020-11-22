var pickUpFastAsPossible = document.getElementById('pickUpFastAsPossible');
var pickUpTime = document.getElementById('pickUpTime');

pickUpFastAsPossible.addEventListener('click', (event) => {
    if (pickUpFastAsPossible.checked == true) {
        pickUpTime.value = null;
        pickUpTime.disabled = true;
    }
    else {
        pickUpTime.disabled = false;
    }
});

var adminChooseCarWash = document.getElementById('adminChooseCarWash');
var CarWashes = document.getElementsByName('CarWashId');

adminChooseCarWash.addEventListener('click', () => {
    if (adminChooseCarWash.checked == true) {
        CarWashes.forEach(x => {
            x.checked = false;
            x.disabled = true;
        });
    }
    else {
        CarWashes.forEach(x => {
            x.disabled = false;
        })
    }
})