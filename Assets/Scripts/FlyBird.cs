using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlyBird : MonoBehaviour
{
    Rigidbody rb;
    Animator an;
    public static int Lives = 3, Score = 0;
    float xForce = 4.5f, yForce = 7;
    float immortalTime = 2;
    bool immortal = false;

    public Text score, lives, hs;

    public static int highscore;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
        Physics.gravity = new Vector3(0, 0, 0);
        highscore = PlayerPrefs.GetInt("HighScore");
    }

    void Update()
    {
        score.text = "Score: " + Score.ToString();
        lives.text = "Lives: " + Lives.ToString();
        hs.text = "HighScore: " + highscore.ToString();

        if (immortal)
            an.SetBool("Flash", true);

        if (Lives < 0)
        {
            score.text = "Score: " + Score.ToString();
            lives.text = "Lives: 0";
            hs.text = "HighScore: " + highscore.ToString();

            if (Score > highscore)
            {
                PlayerPrefs.SetInt("HighScore", Score);
                highscore = Score;
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < Camera.main.orthographicSize)
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
            rb.velocity = new Vector3(xForce * Mathf.Cos(45 * 3.14f / 180), yForce * Mathf.Sin(45 * 3.14f / 180), 0);
        }

        if (Time.time - immortalTime >= 2)
        {
            an.SetBool("Flash", false);
            immortal = false;
        }

        if (Score > highscore)
        {
            PlayerPrefs.SetInt("HighScore", Score);
            highscore = Score;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WallEnd")
        {
            Score++;
        }

        if (other.tag == "Wall" && !immortal)
        {
            Lives--;
            immortal = true;
            immortalTime = Time.time;
        }
    }
}
