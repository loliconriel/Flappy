using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int Score;
    public bool Start_Check;
    public GameObject Spawner;
    public GameObject Score_Text;
    public GameObject Restart_Button;
    public GameObject EndScore;
    public GameObject HighScore;
    public GameObject New;
    public Button Start_Button;
    private void Awake()
    {
        
        Screen.fullScreen = false;
        Screen.SetResolution(1080,1920,FullScreenMode.Windowed); ;
    }
    private void Start()
    {
        Score = 0;
        if (!PlayerPrefs.HasKey("HighScore")) PlayerPrefs.SetInt("HighScore",Score);
        Start_Check = false;
        Score_Text.GetComponent<TextMeshProUGUI>().text = Score.ToString();

    }
    public void Press_Start()
    {
        Time.timeScale = 1f;
        Spawner.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Lose()
    {
        Time.timeScale = 0f;
        Restart_Button.SetActive(true);
        ShowScore();
    }
    public void ShowScore()
    {
       EndScore.GetComponent<TextMeshProUGUI>().text = Score.ToString();
        New.SetActive(false);
        if (PlayerPrefs.GetInt("HighScore") < Score)
        {
            PlayerPrefs.SetInt("HighScore", Score);
            New.SetActive(true);
        }
        HighScore.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore").ToString();

    }
    public void Increase()
    {
        Score++;
        Score_Text.GetComponent<TextMeshProUGUI>().text = Score.ToString();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
