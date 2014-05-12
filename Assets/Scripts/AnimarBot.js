#pragma strict
var anim: Animator;
//funciona quando inicia
function Start () {

//pega o componente "Animator" e armazena na variavel anim
anim = GetComponent("Animator");
//seta a variavel do animator "sele" como true
anim.SetBool("sele", true);

}
//funciona por frame
function Update () {
//stand vai receber 0.1por frame

//se apertar o botao definido como tipo 1
if (Input.GetButton ("l1")||  Input.GetKey (KeyCode.U)) {
anim.SetBool("sele", false);

}
if (Input.GetButton ("r1")||  Input.GetKey (KeyCode.I)){
anim.SetBool("sele", true);

}


	

}
