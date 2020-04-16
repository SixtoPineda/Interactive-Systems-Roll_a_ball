using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara_controller : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        // restar (extraer) la posición de la cámar y la del jugador
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame but a diferencia del Update, pero esto
    // te garantiza que se va a ejecutar después de que se haya procesador
    // todos lo items del Update, y así cuando obtenemos la posición de la cámara
    // ya tenemos toda la info de la nueva pos. del jugador. 
    void LateUpdate()
    {
        // a medida que nos movemos el jugador, antes de mostrar lo que 
        // la cámara ve la cámara se mueve a la nueva posición alineada con 
        // el objeto del jugador. 
        transform.position = player.transform.position + offset;
    }
}
