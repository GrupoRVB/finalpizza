﻿#pragma strict
var anim: Animator;
var stand: float;
function Start () {
//pega o componente "Animator" e armazena na variavel anim

anim = GetComponent("Animator");
//stand(parado por muito tempo) recebe 0
stand = 0;
}

function Update () {
//a cada frame ele recebe o valor 0.01;
stand += 0.01f;
//se stand for maior que 5;
if(stand > 5){
//vai setar bool para a variavel cansado para true;
anim.SetBool("cansado", true);
}
//se frente ou tras, assume posiçao 1(correr) e a variavel stand se torna 0 ( se ele estiver no modo stand, sai dele)
if(Input.GetAxis("Horizontal"))
{
anim.SetInteger("velo", 1);
stand = 0;
anim.SetBool("cansado", false);
}
//se o jogador for pra cima ou para baixo, assume posiçao 1(correr) e a variavel stand se torna 0 ( se ele estiver no modo stand, sai dele)
else if(Input.GetAxis("Vertical"))
{
anim.SetInteger("velo", 1);
stand = 0;
anim.SetBool("cansado", false);
}
//senao for nenhum, fica em parado na posicao 0(idle)
else
{
anim.SetInteger("velo", 0);
}

//Se a tecla padrao de "tiro" for diferente de 0 (ou seja, se ela for 1) 
if (Input.GetAxis ("Tiro") != 0 ||  Input.GetKey (KeyCode.J)) {
//manda para o componente animator na variavel "atirando" true e a variavel stand se torna 0 ( se ele estiver no modo stand, sai dele)
anim.SetBool("atirando", true);
stand = 0;
anim.SetBool("cansado", false);


}else{

//se a tecla nao estiver apertada, manda para o componente animator na variavel "atirando" false
anim.SetBool("atirando", false);
anim.SetBool("atacando", false);
}
// se apertar o botao definido como "l1"
if (Input.GetButton ("l1")||  Input.GetKey (KeyCode.U)) {
//seta o estado tiroforte como true e a variavel stand se torna 0 ( se ele estiver no modo stand, sai dele)
anim.SetBool("tiroforte", true);
stand = 0;
anim.SetBool("cansado", false);
}
//se apertar o botao definido como "r1" 
if (Input.GetButton ("r1")||  Input.GetKey (KeyCode.I)){
//seta o estado tiro forte como false e a variavel stand se torna 0 ( se ele estiver no modo stand, sai dele)
anim.SetBool("tiroforte", false);
stand = 0;
anim.SetBool("cansado", false);
}
//se o jogador apertar o botao definido como "Atacar"  
if(Input.GetButton("Atacar")){
//seta o estado atacando como true e a variavel stand se torna 0 ( se ele estiver no modo stand, sai dele)
anim.SetBool("atacando", true);
stand = 0;
anim.SetBool("cansado", false);
}
}
	