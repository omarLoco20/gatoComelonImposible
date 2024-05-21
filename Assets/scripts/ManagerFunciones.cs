using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerFunciones : MonoBehaviour
{
    public string scenaJuego;

    public void Exit()
    {
        Application.Quit();
    }

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void activarCualquierPnl(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void desactivarCualquierPnl(GameObject panel)
    {
        panel.SetActive(false);
    }



}
