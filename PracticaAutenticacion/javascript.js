/*convertir nombre y apellido a mayusculas*/
var caja1, caja2;

window.onload = function () {
    caja1 = document.getElementById("nombre");
    //detecta el evento pulsando una tecla
    caja1.onkeyup = function () {
        caja1.value = caja1.value.toUpperCase();
    }
    caja2 = document.getElementById("apellido");
    //detecta el evento pulsando una tecla
    caja2.onkeyup = function () {
        caja2.value = caja2.value.toUpperCase();
    }

}

/*validacion del email*/
function validarEmail(email){
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

    if (reg.test(email.value) == false){
        //alert('El mail ingresado no es valido!');
        document.getElementById("msj_error_mail").innerHTML = "El mail ingresado no es valido!";
        return false;
    }
    else{
        document.getElementById("msj_error_mail").innerHTML = "OK!";
        return true;
    }


/*validacion edad solo numeros*/
function validarEdad(edad) {
    var reg = /[0-9]|\./;
    if (reg.test(edad.value) == false){
        //alert('El mail ingresado no es valido!');
        document.getElementById("msj_error_edad").innerHTML = "Ingrese solo numeros!";
        return false;
    }else{
        document.getElementById("msj_error_edad").innerHTML = "OK!";
        return true;
    }
}

function validarTelefono(numero) {
    var reg = /[0-9]|\./;
    if (reg.test(numero.value) == false){
        //alert('El mail ingresado no es valido!');
        document.getElementById("msj_error_numero").innerHTML = "Ingrese solo numeros!";
        return false;
    }else{
        document.getElementById("msj_error_numero").innerHTML = "OK!";
        return true;
    }
}

/*imprimir datos en alert*/
function mostrarDatos() {
    var nombre = document.getElementById("nombre").value;
    var apellido = document.getElementById("apellido").value;
    var edad = document.getElementById("edad").value;
    var mail = document.getElementById("email").value;
    var horario = document.getElementById("horario").value;
    var fecha = document.getElementById("fecha_inicio").value;

    alert("Los datos son: \nNombre: " + nombre + "\n" +
        "Apellido: " + apellido + "\n" +
        "Edad: " + edad + "\n" +
        "Mail: " + mail + "\n" +
        "Fecha: " + fecha + "\n" +
        "Horario: " + horario);
    //alert(nombre + apellido + edad + mail + horario + fecha);
    //alert("Alerta!");

}

/*validar contrasenia*/
function validarPass() {
    var pass1 = document.getElementById("password").value;
    var pass2 = document.getElementById("password2").value;
    var ok = true;

    if (pass1 != pass2) {
        //alert("Contraseñas no concuerdan");
        document.getElementById("password").style.borderColor = "#E34234";
        document.getElementById("password2").style.borderColor = "#E34234";
        ok = false;
        document.getElementById("msj_error_pass").innerHTML = "Contraseñas no concuerdan!";
    }
    else {
        //alert("Correcto!!!");
        document.getElementById("msj_error_pass").innerHTML = "Correcto!";
    }
    return ok;
}

}





