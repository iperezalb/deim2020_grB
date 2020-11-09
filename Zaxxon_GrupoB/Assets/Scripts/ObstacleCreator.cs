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
<<<<<<< HEAD
    private float randomNumberZ;
    Vector3 RandomPos;
   
    // Start is called before the first frame update
    void Start()
    {
=======
    Vector3 RandomPos;

    //Distancia a la que se crean las columnas iniciales
    [SerializeField] float distanciaInicial = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        //Creo las columnas iniciales
        for(int n = 1; n <= 30; n++)
        {
            
            CrearColumna(-n * distanciaInicial);
        }
        
>>>>>>> 2f17e020f30995d65e275104e21edc7a5ccb879b
        //Lanzo la corrutina
        StartCoroutine("InstanciadorColumnas");

    }

    //Función que crea una columna en una posición Random
<<<<<<< HEAD
    void CrearColumna()
    {
        randomNumber = Random.Range(-6f, 8f);
        randomNumberZ = Random.Range(0f, 80f);
        RandomPos = new Vector3(randomNumber, 0, randomNumberZ);
        //print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPos;
        Instantiate(Columna, FinalPos, Quaternion.identity);

       
        
=======
    void CrearColumna(float posZ = 0f)
    {
        randomNumber = Random.Range(0f, 7f);
        RandomPos = new Vector3(randomNumber, 0, posZ);
        //print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPos;
        Instantiate(Columna, FinalPos, Quaternion.identity);
>>>>>>> 2f17e020f30995d65e275104e21edc7a5ccb879b
    }

    //Corrutina que se ejecuta cada segundo
    //NOTA: habría que cambiar ese segundo por una variable que dependa de la velocidad
    IEnumerator InstanciadorColumnas()
    {
        //Bucle infinito (poner esto es lo mismo que while(true){}
        for (; ; )
        {
            CrearColumna();
            yield return new WaitForSeconds(1f);
        }

    }


}
