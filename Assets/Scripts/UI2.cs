using UnityEngine;
using UnityEngine.SceneManagement;

public class UI2 : MonoBehaviour
{
    public GameObject pause, resume, exit;

    private void Start()
    {
        pause.SetActive(true);
        resume.SetActive(false);
        exit.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pause.SetActive(false);
        resume.SetActive(true);
        exit.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pause.SetActive(true);
        resume.SetActive(false);
        exit.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
