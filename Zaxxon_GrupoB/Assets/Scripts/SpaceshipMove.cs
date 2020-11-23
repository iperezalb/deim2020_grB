using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI

public class SpaceshipMove : MonoBehaviour
{
    //--SCRIPT PARA MOVER LA NAVE --//

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed = 3f;

    //Variable PRIVADA que indica la velocidad a la que se desplaza la nave en horizontal y vertical 
    //por el control del jugador.
    private float moveSpeed = 3f;
    
    //Variables PRIVADA que guarda la distancia recorrida por la nave
    private float distance;

    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;
    [SerializeField] Text TextVelocidad;

    //La variable myMesh de la clase MeshRenderer se crea para enlazar el renderizado de la nave y poder desactivarlo al chocar con un prefab
    [SerializeField] MeshRenderer myMesh;


    // Start is called before the first frame update
    void Start()
    {
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");
       


    }

    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave();

    }

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 10 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito

        for(int n = 0; ; n++)
        {
            //Actualizacion de la distancia recorrida por la nave, salvo cuando la velocidad es = 0, ya que significa que has perdido
            //Y la distancia se queda en el ultimo valor antes de chocar
            if(speed != 0)
            {
                distance = n * speed;
            }

            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + distance;

            //Si la nave ha recorrido 300 unidades de distancia la velocidad aumenta a 5f
            if (distance >= 300f && distance <= 800f)
            {
                speed = 5f;
            }
            //Si la nave ha recorrido 800 unidades de distancia la velocidad aumenta a 7f
            else if (distance > 800f)
            {
                speed = 7f;
            }
            
            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(0.25f);
        }
        
    }

  

    void MoverNave()
    {
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        if (transform.position.x < -5.5f && desplX < 0)
        {
            desplX = 0f;
        }
        else if (transform.position.x > 5.5f && desplX > 0)
        {
            desplX = 0f;
        }

        float desplY = Input.GetAxis("Vertical");
        if (transform.position.y < -0.35f && desplY < 0)
        {
            desplY = 0f;
        }
        else if (transform.position.y > 3.5f && desplY > 0)
        {
            desplY = 0f;
        }

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);
    }

    void OnCollisionEnter(Collision collision)
    {
        speed = 0f;
        
        myMesh.enabled = false;
        
    }
}
