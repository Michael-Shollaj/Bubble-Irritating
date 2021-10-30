using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _lifeText;
    [SerializeField] private int _initialLife = 10;          // On reset i.e gameover
    [SerializeField] private GameObject _pauseMenu;

    public GameObject _gameOverScreen;
    public GameObject _continueScreen;

    private void OnEnable()
    {
        if(_instance == null) { _instance = this; }
      
        StartCoroutine(BallCounter());
    }

    void Start()
    {
    }

    void Update()
    {
        _scoreText.text = PlayerController.score.ToString();
        _lifeText.text ="X " + PlayerController._lifeCount;

        if (BallController.ballCount <=0)
        {
            _continueScreen.SetActive(true);
        }

        // If continue or game over screen is active then do show pause menu
        if(_continueScreen.activeSelf || _gameOverScreen.activeSelf)
        {
            Time.timeScale = 1f;        // when pressing on continue/gameoverscreen wont slowdwn the time
            _pauseMenu.SetActive(false);
            GameObject.FindObjectOfType<PlayerController>().enabled = false;
        }
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
      //  ResetLife();
    }

    // To count the number of balls currently active; So as to open the Continue UI
    private IEnumerator BallCounter()
    {
        BallController.ballCount = GameObject.FindObjectsOfType<BallController>().Length;

        yield return new WaitForSeconds(1f);
        StartCoroutine(BallCounter());
    }

    public void ResetLife()
    {
        GameObject.FindObjectOfType<PlayerController>().enabled = true;
        PlayerController._lifeCount = _initialLife;
    }
}
