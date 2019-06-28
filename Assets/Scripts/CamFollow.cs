using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamFollow : MonoBehaviour {

    public GameObject player;
    Vector3 offset = new Vector3(2, 0, 0);
    public Vector3 OutOfScreen;
    public bool CheckWall = false;

    private void Update()
    {
        if (player.transform.position.x > Camera.main.transform.position.x - offset.x)
            Camera.main.transform.position= new Vector3(player.transform.position.x, Camera.main.transform.position.y, -10) + offset;

        if (player.transform.position.x > transform.position.x - offset.x + OutOfScreen.x)
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z) + offset + OutOfScreen;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bird")
        {
            if (FlyBird.Score > FlyBird.highscore)
            {
                PlayerPrefs.SetInt("HighScore", FlyBird.Score);
                FlyBird.highscore = FlyBird.Score;
            }
            FlyBird.Score = 0;
            FlyBird.Lives = 3;
            SceneManager.LoadScene(1);
        }

        if (other.tag == "WallCover" && CheckWall)
        {
            other.gameObject.SetActive(false);
        }
    }
}
