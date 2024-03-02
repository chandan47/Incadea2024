document.getElementById('registrationForm').addEventListener('submit', function(event) {
    event.preventDefault();
    var name = document.getElementById('name').value;
    var age = document.getElementById('age').value;
    var gender = document.querySelector('input[name="gender"]:checked');
    var registrationNumber = document.getElementById('registrationNumber').value;
    var email = document.getElementById('email').value;
    var phoneNumber = document.getElementById('phoneNumber').value;
    var password = document.getElementById('password').value;

    var errors = [];
    if (!name) {
      errors.push("Name is required");
    }
    if (age < 11 || age > 99) {
      errors.push("Age must be a number between 11 and 99");
    }
    if (!gender) {
      errors.push("Gender is required");
    }
    if (!registrationNumber) {
      errors.push("Registration Number is required");
    }
    if (!email.match(/\S+@\S+\.\S+/)) {
      errors.push("Invalid email address");
    }
    if (!phoneNumber.match(/^\d{10}$/)) {
      errors.push("Phone number must contain 10 digits");
    }
    if (password.length < 6 || !password.match(/[\W_]/)) {
      errors.push("Password must be at least 6 characters long and contain at least one special character");
    }

    if (errors.length > 0) {
      alert(errors.join('\n'));
    } else {
      alert("Registration successful!");
      window.location.href = "signup.html";
    }
  });
