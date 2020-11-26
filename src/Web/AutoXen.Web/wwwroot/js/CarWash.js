var adminChooseCarWash = document.getElementById('AdminChooseCarWash');
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