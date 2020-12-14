var adminChooseCarWash = document.getElementById('AdminChooseCarWash');
var CarWashes = document.getElementsByName('CarWashId');

let checked = false;
CarWashes.forEach(x => {
    if (x.checked) {
        checked = true;
    }
})

if (adminChooseCarWash.checked) {
    CarWashes.forEach(x => {
        x.disabled = true;
        x.checked = false;
    })
}

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