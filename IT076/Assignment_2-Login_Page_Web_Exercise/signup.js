document.getElementById('signupForm').addEventListener('submit', function(event) {
    event.preventDefault();
    var name = document.getElementById('name').value;
    var password = document.getElementById('password').value;

    var Name = "akshay";
    var Password = "akshay@123";

    if (name === Name && password === Password) {
      alert("Successful!");
    } else {
      alert("Sign up failed. Please check your credentials.");
    }l̥
  });

