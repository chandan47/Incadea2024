function validateForm(){
    var username=document.getElementById("username").value;
   var password=document.getElementById("password").value;
   if(username.trim()===""||password.trim()===""){
       alert("UserName and Password required");
      
   }
   else if(username.length<4){
        alert("UserName should be minimum three characters");
   }
   else if(password.length<8){
       alert("Password should  be minimum eight character");
   }
   else{
       alert("User Logged in Successfully");
     
   }
   
    }