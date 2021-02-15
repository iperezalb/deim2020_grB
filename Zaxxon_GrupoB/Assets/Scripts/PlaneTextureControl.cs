using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTextureControl : MonoBehaviour
{
    //componente de tipo renderer
    Renderer rend;
    //vector de desplazamiento
    [SerializeField] Vector2 despl;
    //Datos del juego
    SpaceshipMove initgame;

    // Start is called before the first frame update
    void Start()
    {
        //Asignamos el componente Renderer
        rend = GetComponent<Renderer>();

        //Buscamos dentro del proyecto el script de la nave para obtener su velocidad
        GameObject InitEmpty = GameObject.Find("Spaceship");
        initgame = InitEmpty.GetComponent<SpaceshipMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //Velocidad de desplazamiento de la textura, que depende de la de la nave
        float scrollSpeed = initgame.speed / 3f;

        //Multiplicamos el tiempo (Time.time) por la velocidad (scrollSpeed) para obtener la distancia de desplazamiento de la textura.
        float offset = Time.time * scrollSpeed;

        //Vector creado para aplicar el desplazamiento en el eje correspondiente.
        despl = new Vector2(0, -offset);

        //Aplicamos el desplazamiento a la textura
        rend.material.SetTextureOffset("_MainTex", despl);
        rend.material.SetTextureOffset("_BumpMap", despl);

    }
}
