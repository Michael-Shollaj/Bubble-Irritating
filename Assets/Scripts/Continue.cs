using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{

    [SerializeField] private Text _score;
    [SerializeField] private string _mainMenu = "Main_Menu";
    [SerializeField] private string _nextLevel;


    private void Start()
    {
        StartCoroutine(ScoreAnim());
    }

    private IEnumerator ScoreAnim()
    {
        int temp = 0;

        while(temp <= PlayerController.score)
        {
            _score.text = temp.ToString();
            temp++;
            yield return new WaitForSeconds(.05f);
        }

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(_nextLevel);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(_mainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
