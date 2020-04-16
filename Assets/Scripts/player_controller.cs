using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player_controller : MonoBehaviour
{

    public float speed;
    public Text count_text;
    public Text win_text;
    public AudioClip pickup;

    private Rigidbody rb;
    private int count;




    // Start is called before the first frame update
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCount_text();
        win_text.text = "";


    }


    // Se usa cada vez que se hacer cualquier physic perform calculations (physiscs)
    void FixedUpdate ()
    {
        // GetAxis:  nos devuelve el valor de los ejes
        // Input: lo usamos para leer los ejes del inout manager o el movil

        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        // RigidBody: Control de posició de un objeto mediante physics simulation
        //AddForce: añade force al RigidBody

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // Tag: para saber el nombre del Objeto
        // SetActive: para activar (True) o no (False) un objeto, que aparezca o no, sin eliminar
        // CompareTag: para comparar un Tag de un objeto con una string

        if (other.gameObject.CompareTag("Pick_Up"))
        {
            AudioSource.PlayClipAtPoint(pickup, transform.position);
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCount_text();

        }
        if(count >= 6)
        {
            win_text.text = "¡YOU WIN! XD";
        }

    }

    //Funcion para plotear el número de puntos actualizado
    void SetCount_text()
    {
        count_text.text = "Count: " + count.ToString();
    }




}