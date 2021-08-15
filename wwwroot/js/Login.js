

function validate(){
    var username = document.getElementById("Usuario").value;
    var password = document.getElementById("Password").value;
    if ( username == "Brandon" && password == "1234"){
    alert ("Ingresó Correctamente");
    return false;
    }
    else if ( username == "Brayan" && password == "1234"){
        alert ("Ingresó Correctamente");
        return false;
    }
    
}
