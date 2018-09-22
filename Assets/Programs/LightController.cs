using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    //Privadas
    private bool playerInRange = false;
    private GameObject player;
    private Light luz;

    //Publicas
    public float velocidadeInicial = 1f;
    public float aceleration;

    //Variaveis auxiliaress
    private Vector3 InicialPosition;
    private float multiplicador;
    
    
	void Start () {
        luz = GetComponent<Light>();
        player = GameObject.FindGameObjectWithTag("Player");
        InicialPosition = this.transform.position;
        multiplicador = velocidadeInicial   ;
	}
	
	void Update () {
        if (playerInRange) {
            seguirPlayer();
        }
        //Quando estão perto o suficiente
        if (Vector3.Distance(transform.position, player.transform.position)< 0.1f) {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter(Collider other) {    
        if(other.tag == "Player") {
            playerInRange = true;
        }
    }

    void seguirPlayer() {
        //Segue o player aceleradamente
        this.transform.position = Vector3.Lerp(InicialPosition, player.transform.position, Mathf.Clamp01(multiplicador * Time.deltaTime));
        //Aumenta o brilho exponencialmente
        luz.intensity = Mathf.Lerp(0, 1, multiplicador * Time.deltaTime);
        //Atualiza o multiplicador
        multiplicador = multiplicador + multiplicador * aceleration * Time.deltaTime;
    }


}
