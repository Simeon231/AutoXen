function GetInsurerInsurances(insurer) {
    const id = insurer.selectedOptions[0].value;
    fetch(`/api/InsurerInsurance/${id}`)
        .then(resources => resources.json())
        .then(data => {
            AddInsuracesToSelect(data);
        });
}

function AddInsuracesToSelect(data) {
    const insurancesSelect = document.getElementById("insurances");
    console.log(data);
    insurancesSelect.disabled = false;
    insurancesSelect.innerHTML = null;

    data.forEach(x => {
        const option = document.createElement("option");
        option.text = `${x.insuranceName} - ${x.price}lv`
        option.value = x.insuranceId;

        insurancesSelect.add(option);
    })
}