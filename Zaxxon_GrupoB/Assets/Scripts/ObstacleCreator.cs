using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    //---SCRIPT ASOCIADO AL EMPTY OBJECT QUE CREARÁ LOS OBSTÁCULOS--//

    //Variable que contendré el prefab con el obstáculo
    [SerializeField] GameObject Columna;

    //Variable que tiene la posición del objeto de referencia
    [SerializeField] Transform InitPos;

    //Variables para generar columnas de forma random
    private float randomNumber;
    Vector3 RandomPos;
    [SerializeField] float distanciaInicial = 5;

    public GameObject SpaceShip;
    SpaceshipMove spaceshipMove;

    private float velocidadColumnas;

    // Start is called before the first frame update
    void Start()
    {
        //Creo las columnas iniciales
        for(int n = 1; n <= 30; n++)
        {
            
            CrearColumna(-n * distanciaInicial);
        }
        
        //Lanzo la corrutina
        StartCoroutine("InstanciadorColumnas");

        SpaceShip = GameObject.Find("Spaceship");
        spaceshipMove = SpaceShip.GetComponent<SpaceshipMove>();
    }

    //Función que crea una columna en una posición Random
    void CrearColumna(float posZ = 0f)
    {
        randomNumber = Random.Range(-5f, 5f);
        RandomPos = new Vector3(randomNumber, 0, posZ);
        //print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPos;
        Instantiate(Columna, FinalPos, Quaternion.identity);
    }

    //Corrutina que se ejecuta cada segundo
    //NOTA: habría que cambiar ese segundo por una variable que dependa de la velocidad
   
        IEnumerator InstanciadorColumnas()
        {
            //Bucle infinito (poner esto es lo mismo que while(true){}
            for (; ; )
            {

                //He leido en internet que esta linea tiene que ir arriba de la corrutina. Si no se rompia el programa
                yield return new WaitForSeconds(velocidadColumnas);

                CrearColumna();

                //Dependiendo de la velocidad a la que vaya la nave, la corrutina hara que se genere el mismo nurmero de columnas en menos tiempo 
                if (spaceshipMove.speed == 3f)
                {
                    velocidadColumnas = 1f;
                }
                else if (spaceshipMove.speed == 5f)
                {
                    velocidadColumnas = 0.8f;
                }
                else if (spaceshipMove.speed == 7f)
                {
                    velocidadColumnas = 0.6f;
                }
                else
                {
                    velocidadColumnas = 1f;
                }
            }

    }
}
