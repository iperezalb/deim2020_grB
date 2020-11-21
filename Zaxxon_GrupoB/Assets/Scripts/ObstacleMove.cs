﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    //Creamos la variable a la que se moverá el obtáculo
    //Este valor deberá depender de la velocidad de la nave
    private float obstacleSpeed;

    public GameObject SpaceShip;
    SpaceshipMove spaceshipMove;

    // Start is called before the first frame update
    void Start()
    {
        //Con estas dos lineas de codigo, cada prefab encuentra la nave y guarda su informacion en una variable 
        SpaceShip = GameObject.Find("Spaceship");
        spaceshipMove = SpaceShip.GetComponent<SpaceshipMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Comprobamos si la instancia ha rebasado a la nave y la destruimos
        //NOTA: habría que pasar esto a una CORRUTINA para consumir menos recursos
        float PosZ = transform.position.z;
        if(PosZ < -12)
        {
            Destroy(gameObject);
        }

        //Asignamos la misma velocidad que la de la nave a los prefabs
        transform.Translate(Vector3.back * Time.deltaTime * spaceshipMove.speed);
 
    }
}
