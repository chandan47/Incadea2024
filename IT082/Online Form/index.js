function getData()
{
    var fname = document.getElementById("fname").value;
    var lname = document.getElementById("lname").value;
    var Phone = document.getElementById("Phone").value;
    var age = document.getElementById("age").value;
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var Repassword = document.getElementById("Repassword").value;

    if(age>120)
        {
            alert("Please enter a valid age");
        }
    if(!email.endsWith(".com"))
    {
        alert("Please enter a valid email address");
    }
    if(password != Repassword)
    {
        alert("Passwords Doesn't matches");
    }
    if (Phone.length != 10)
    {
        alert("Please enter a valid phone number");
    }
    if(password.length <= 8)
    {
        alert("Enter a password of minimum 8 characters ");
    }
    
    if(age<120 && email.endsWith("@gmail.com") && password == Repassword && password.length >= 8 && Phone.length == 10)
    {
        alert("Form submitted successfully");
    }

}