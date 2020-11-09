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

    //Variable que determina cómo de rápido se mueve la nave con el joystick
    //De momento fija, ya veremos si aumenta con la velocidad o con powerUps
    private float moveSpeed = 3f;
<<<<<<< HEAD
=======
    //Variable que determina si estoy en los márgenes
    private bool inMarginMoveX = true;
    private bool inMarginMoveY = true;
>>>>>>> 2f17e020f30995d65e275104e21edc7a5ccb879b

    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;
    
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
<<<<<<< HEAD
        for(int n = 0; ; n += 10)
=======
        for(int n = 0; ; n += 2)
>>>>>>> 2f17e020f30995d65e275104e21edc7a5ccb879b
        {
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + n;

            //Ejecuto cada ciclo esperando 1 segundo
<<<<<<< HEAD
            yield return new WaitForSeconds(1f);
=======
            yield return new WaitForSeconds(0.1f);
>>>>>>> 2f17e020f30995d65e275104e21edc7a5ccb879b
        }
        
    }



    void MoverNave()
    {
<<<<<<< HEAD
=======
        
        
>>>>>>> 2f17e020f30995d65e275104e21edc7a5ccb879b
        /*
        //Ejemplos de Input que podemos usar más adelante
        if(Input.GetKey(KeyCode.Space))
        {
            print("Se está pulsando");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            print("Se está disparando");
        }
        */
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
<<<<<<< HEAD

        if (transform.position.x < -5f && desplX < 0)
        {
            desplX = 0f;
        }
        else if (transform.position.x > 5f && desplX > 0)
        {
            desplX = 0f;
        }
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
        float desplY = Input.GetAxis("Vertical");

        if (transform.position.y < -0.35f && desplY < 0)
        {
            desplY = 0f;
        }
        else if (transform.position.y > 3.5f && desplY > 0)
        {
            desplY = 0f;
        }
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);

        
=======
        float desplY = Input.GetAxis("Vertical");

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave

        print(transform.position.x);
        float myPosX = transform.position.x;
        float myPosY = transform.position.y;

        //Lanzamos el método que nos comprueba la restricción en X y en Y
        checkRestrX(myPosX, desplX);
        checkRestrY(myPosY, desplY);

        //Si estoy en los márgenes, me muevo
        if (inMarginMoveX)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
        }
        if(inMarginMoveY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);
        }

    }

    void checkRestrX(float myPosX, float desplX)
    {
        if (myPosX < -4.5 && desplX < 0)
        {
            inMarginMoveX = false;
        }
        else if (myPosX < -4.5 && desplX > 0)
        {
            inMarginMoveX = true;
        }
        else if (myPosX > 4.5 && desplX > 0)
        {
            inMarginMoveX = false;
        }
        else if (myPosX > 4.5 && desplX < 0)
        {
            inMarginMoveX = true;
        }
    }

    void checkRestrY(float myPosY, float desplY)
    {
        //Retricción en Y
        if (myPosY < -0 && desplY < 0)
        {
            inMarginMoveY = false;
        }
        else if (myPosY < -0 && desplY > 0)
        {
            inMarginMoveY = true;
        }
        else if (myPosY > 4 && desplY > 0)
        {
            inMarginMoveY = false;
        }
        else if (myPosY > 4 && desplY < 0)
        {
            inMarginMoveY = true;
        }
>>>>>>> 2f17e020f30995d65e275104e21edc7a5ccb879b
    }
}
