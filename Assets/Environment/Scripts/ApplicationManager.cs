using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{

    public void ChangeScenes(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
