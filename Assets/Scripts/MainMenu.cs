using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private string _levelToLoad = "Level_01";

   public void NextLevel()
    {
        SceneManager.LoadScene(_levelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
