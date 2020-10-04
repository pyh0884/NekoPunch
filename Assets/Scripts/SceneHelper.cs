using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    public void quickLoadScene(int SceneIndex) 
    {
        SceneManager.LoadScene(SceneIndex);
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
}
