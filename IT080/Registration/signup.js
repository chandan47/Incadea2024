function ValidateForm(){
    const Username=document.getElementById('Username').value.trim();
    const Phone=document.getElementById('Phone').value.trim();
    const email=document.getElementById('Email_id').value.trim();
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    
    const password=document.getElementById('password').value.trim();
    const re_enter_password=document.getElementById('Re enter password').value.trim();
   
    if(!Username){
        alert('User name is reqired');
        return;
    }

    if(!Phone){
        alert('Phone number is required');
        return;
    }
    if(Phone.length!=10){
        alert("Enter your corrcet 10 digit phone number");
        return;
    }
    if(!email){
        alert('Email id is required');
        return;
    }
    if(!email.match(emailPattern)){
        alert("Enter your correct email id");
        return;
    }
    if(!password){
        alert('Password is required');
        return;
    }
    if(password.length<6){
        alert('password atleast should have 6 characters');
        return;

    }

    if(password!=re_enter_password){
        alert("Password is not matching with Re enter Password");
        return;
    }
    console.log("Form Submitted Successfully");
    alert("Form submitted successfully");

}