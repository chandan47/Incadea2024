function validateForm(){
    var username=document.getElementById("username").value.trim();
    var email=document.getElementById("email").value.trim();
    var phonenumber=document.getElementById("phonenumber").value.trim();
    var password=document.getElementById("password").value.trim();
    var re_password=document.getElementById("re-password").value.trim();
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
    if(username===""||email===""||phonenumber===""||password===""||re_password===""){
        alert("All fields are required");
    }
    else if(username.length<4){
  alert("UserName should be minimum three characters");
    }
    else if(!email.match(mailformat)){
        alert(" Email-Incorrect Format");

    }
    else if(phonenumber.length!=10){
        alert("Phonenumber should consists 10 digits");
    }
    else if(password<8||re_password<8)
    {
        alert("Password should be minimum 8 characters");
    }
    else if(password!=re_password){
        alert("Password is not matching");
    }
    else{
        alert("Registration Successfull")
    }
}