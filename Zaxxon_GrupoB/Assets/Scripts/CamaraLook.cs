using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{

    [SerializeField] Transform playerPosition;
    //Variables necesarias para la opción de suavizado
    [SerializeField] float smoothVelocity = 0.3F;
    private Vector3 camaraVelocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        transform.position = new Vector3(Tarjet.position.x, Tarjet.position.y + 0.5f, Tarjet.position.z - 5f);
       
=======
        //transform.LookAt(Tarjet);
        Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref camaraVelocity, smoothVelocity);
>>>>>>> 2f17e020f30995d65e275104e21edc7a5ccb879b
    }
}
