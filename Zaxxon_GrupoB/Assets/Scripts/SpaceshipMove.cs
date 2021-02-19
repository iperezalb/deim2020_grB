using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI
using UnityEngine.SceneManagement;



public class SpaceshipMove : MonoBehaviour
{
    //--SCRIPT PARA MOVER LA NAVE --//

    //Variable PUBLICA que indica cuando se ha terminado el juego
    public bool gameOver = false;

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed = 3f;

    //Variable PRIVADA que indica la velocidad a la que se desplaza la nave en horizontal y vertical 
    //por el control del jugador.
    private float moveSpeed = 3f;
    
    //Variables PRIVADA que guarda la distancia recorrida por la nave
    private float distance;

    //Varriables enlazadas con Unity con los textos que indican la distancia y la velocidad
    [SerializeField] Text TextDistance;
    [SerializeField] Text TextVelocity;
   
    //La variable myMesh de la clase MeshRenderer se crea para enlazar el renderizado de la nave y poder desactivarlo al chocar con un prefab
    [SerializeField] MeshRenderer myMesh;

    // Variables para recrear explosion
    GameObject MakedObject;
    public GameObject AllEffect;

    AudioSource audioSource;
    [SerializeField] AudioClip VueloNave;
    [SerializeField] AudioClip ExplosionSound;
    [SerializeField] AudioClip AmbientGameSound;


    // Start is called before the first frame update
    void Start()
    {
        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");

        //Obtenemos el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        //Ejecutamos el sonido del vuelo de la nave
        audioSource.PlayOneShot(VueloNave, 3f);

        //Ejecutamos el sonido de ambiente del juego
        audioSource.PlayOneShot(AmbientGameSound, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick sólo si el juego no se ha terminado
        if(gameOver == false)
        {
            MoverNave();
        }
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
            TextVelocity.text = "VELOCIDAD: " + speed;

            //Si la nave ha recorrido 200 unidades de distancia la velocidad aumenta progresivmente hasta 10f
            if (distance >= 200f && distance <= 500f && speed < 10f)
            {
                speed = speed + 0.1f;
            }
            //Si la nave ha recorrido 500 unidades de distancia la velocidad progresivmente hasta 15f, que es el limite del juego
            else if (distance > 500f && speed < 15f)
            {
                speed = speed + 0.1f;
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
        //Space.World se utiliza para que el movimiento sea relativo a los ejes del mundo y la rotación de la nave no afecte a su movimiento horizontal y vertical.
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX, Space.World);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY, Space.World);

        //Con transform.rotation hacemos que la rotación en Z de la nave dependa directamente del desplX (movimiento horizontal), es decir, que cuando no se pulsa ninguna tecla la nave está en horizontal.
        //Al pulsar la tecla derecha la nave se inclina hacia la derecha y lo mismo sucede con la tecla izquierda. 50 es el ángulo máximo de inclinación de la nave.
        transform.rotation = Quaternion.Euler(0, 0, desplX * -50);


    }

    // Metodo que se ejecuta automaticamente en caso de una colision 
    void OnCollisionEnter(Collision collision)
    {
        // Se actualiza la variable que guarda si la partida o no se ha terminado
        gameOver = true;

        // La velocidad del juego se vuelve a 0 y se para la corrutina donde se aumenta la velocidad para evitar errores
        speed = 0f;
        StopCoroutine("Distancia");

        // Desaparece el renderizado 3D de la nave para dar la ilusion de que ha desaparecido el objeto
        myMesh.enabled = false;

        //SceneManager.LoadScene(2);

        //Aparece una explosion
        MakedObject = Instantiate(AllEffect, transform.position, transform.rotation) as GameObject;
        
        //Se eliminan todos los sonidos asociados al componente AudioSource() de la nave, como el ruido de los motores
        audioSource.Stop();

        //Ejecutamos el sonido del vuelo de la nave
        audioSource.PlayOneShot(ExplosionSound, 1f);

        // Se inicia una corrutina que espera X segundos antes de la pantalla de GameOver

        StartCoroutine("WaitAndGameOver");

    }

    // Creacion de corrutina para esperar a la animacion de la explosion y despues hacer game over
    IEnumerator WaitAndGameOver()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(2);
    }
}
