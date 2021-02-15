using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_menus : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip AudioMenu;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Ejecutamos el sonido del menu del juego
        audioSource.PlayOneShot(AudioMenu, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
