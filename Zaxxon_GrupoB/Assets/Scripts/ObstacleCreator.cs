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

    // Start is called before the first frame update
    void Start()
    {
        //Creo las columnas iniciales
        for (int n = 1; n <= 30; n++)
        {
            CrearColumna(-n * distanciaInicial);
        }
        SpaceShip = GameObject.Find("Spaceship");
        spaceshipMove = SpaceShip.GetComponent<SpaceshipMove>();

        //Lanzo la corrutina
        StartCoroutine("InstanciadorColumnas");
    }

    void Update()
    {
        if(spaceshipMove.gameOver == true)
        {
            StopCoroutine("InstanciadorColumnas");
        }
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

    //Corrutina que depende de la velocidad de la nave
    IEnumerator InstanciadorColumnas()
    {
        //Bucle infinito (poner esto es lo mismo que while(true){}
        for (; ; )
        {
            CrearColumna();

            // La variable float interval indica el tiempo que espera la corrutina antes de lanzar otra columna, a menor tiempo, mas columnas
            float interval = 4 / spaceshipMove.speed;

            yield return new WaitForSeconds(interval);
        }
    }
}
