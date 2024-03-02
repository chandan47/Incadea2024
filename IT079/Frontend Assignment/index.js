function submitData() {
    var username = document.getElementById("username").value;
    var email = document.getElementById("myEmail").value;
    var phno = document.getElementById("phno").value;
    var password = document.getElementById("password").value;
    var confirmPassword = document.getElementById("confirmPassword").value;
    var specialChars = /[{@#!$%^&*:;'"?><,._\-+=]/g;
    var checkPhno = /[^0-9]/g;
    console.log(typeof(username), typeof(email), typeof(password), typeof(confirmPassword), typeof(phno))
    if(username.length < 4){
        alert("Username has to be min. 4 characters")
    }
    if(!email.endsWith("@gmail.com")){
        alert("Please provide email ends with @gmail.com")
    }
    if(phno.length != 10 && phno.search(checkPhno) == -1){
        alert("Please provide valid Phone number")
    }
    if(password.length < 8){
        alert("Password Length has to min. 8 characters")
    }
    if(password.search(specialChars) == -1){
        alert("Please use special characters in password")
    }
    if(password != confirmPassword){
        alert("Password not matching")
    }
    if(username.length >= 4 && email.endsWith("@gmail.com") && password.length >= 8 && password == confirmPassword && phno.length == 10 && password.search(specialChars) != -1){
        console.log(password.search(specialChars))
        alert("Successfully... Registered")
    }
}