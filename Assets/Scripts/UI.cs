using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text hs;

    private void Start()
    {
        hs.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
