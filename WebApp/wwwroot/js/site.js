document.getElementById('formLogIn').addEventListener('submit', function (e) { // Adds a listener for the submit button in the form doccument thing
    e.preventDefault(); // stop actual submit for now

    let allValid = true;
    let testMessage;


    // Loop through all inputs inside the form
    this.querySelectorAll('.form-control').forEach(input => {
        const isOptonal = input.dataset.optional === "true";

        if (!isOptonal && input.value.trim() === "") {
            input.classList.add('invalid'); //adds 'invalid' to end of the current inputs class name
            input.classList.remove('valid');
            allValid = false;
            testMessage = 'test 1';
        }
        else if (input.value.trim() !== "") { // has value
            input.classList.add('valid');
            input.classList.remove('invalid');
        }
        else {
            input.classList.remove('valid', 'invalid');
        }
    });

    if (allValid) {
        // Only allow sumbission if all valid
        this.submit(); // remove e.preventDefault() effect
    } else {
        result2 = confirm("what?");
        result = prompt("What do you want to print to console?", "hello:)");
        alert('Please fill all fields');
        console.log(result2);
        console.log(result);
    }
});