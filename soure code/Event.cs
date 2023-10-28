using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    public void Replay () 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame () 
    {
        Application.Quit();
    }
}
