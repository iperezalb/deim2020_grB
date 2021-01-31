using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CtrlBotones : MonoBehaviour
{
    public void BotonInicio()
    {
        SceneManager.LoadScene(1);
    }

    public void BotonSalir()
    {
        //Este código se usa para salir del juego cuando este está ya en funcionamiento.
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
  
    public void BotonHighScore()
    {
        SceneManager.LoadScene(3);
    }
    public void BotonBack()
    {
        SceneManager.LoadScene(0);
    }

}
