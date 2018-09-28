using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float PercentageMoved;                  //Qual a porcentagem de terreno deslocado pelo jogador
    private float IniAngle;                         //Angulo inicial da luz do jogador
    private float Counter;                          //Temporizador
    private float CurrentSpeed;                     //Velocidade atual atribuida ao jogador
    private CharacterController Controller;         
    private bool SeenFriend;                        //Booleana que controla se o jogador está "vendo" o item
    public GameObject Light;
    public GameObject Camera;
    public float Timer;                             //Tempo que a luz do jogador aumentará após coletar um item
    public float Speed;                             //A velocidade do jogador
    public float FriendCounter;                     //Quantos itens o jogador colecionou até agora
    public float Range;                             //A distância em que o jogador consegue identificar um novo item
    public float Xlimite;                           //Os limite laterais em que o jogador pode se locomover
    public float Zlimite;                           //Os limite longitudinais em que o jogador pode se locomover
    
    
    // Use this for initialization
    void Start () {
        Controller = gameObject.GetComponent<CharacterController>();
        SeenFriend = false;
        CurrentSpeed = Speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Restringe a posição do jogador no espaço designado
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, -Xlimite, Xlimite), gameObject.transform.position.y, Mathf.Clamp(gameObject.transform.position.z, -Zlimite, Zlimite));
        //Faz a câmera acompanhar o jogador no eixo Z(longitudinal)
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, gameObject.transform.position.z);
        if(!SeenFriend)
        {
            Collider[] ColliderList;
            ColliderList = Physics.OverlapSphere(gameObject.transform.position, Range);
            foreach (Collider element in ColliderList)                  //Procura por um item usando uma esfera de raio Range
            {
                if (element.gameObject.tag == "Friend")                 //Caso encontre Inicie os efeitos no jogador
                {
                    IniAngle = Light.GetComponent<Light>().spotAngle;
                    SeenFriend = true;
                    FriendCounter++;
                    Counter = Time.time;
                }
            }
        }
        else if(Counter + Timer > Time.time)
        {
            Light.GetComponent<Light>().spotAngle += Time.deltaTime * IniAngle / (Timer * 8);
            CurrentSpeed = 0;
        }
        else
        {
            CurrentSpeed = Speed;
            SeenFriend = false;
        }


        //Movimenta o jogador
        Controller.Move(gameObject.transform.forward * CurrentSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
        Controller.Move(gameObject.transform.right * CurrentSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    public float GetPercentageMoved()    //Função que retorna a porcentagem de deslocamento do jogador em relação ao mapa
    {
        PercentageMoved = (gameObject.transform.position.z + Zlimite) / (2 * Zlimite) *100;
        return PercentageMoved;
    }
}
