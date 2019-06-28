using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public GameObject Wall;
    List<GameObject> Walls;
    float distanceBetweenWalls = 8f;

    int WallCount = 1;

    void Start()
    {
        Walls = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            Walls.Add(Instantiate(Wall, transform.position, Quaternion.identity));
            Walls[i].gameObject.SetActive(false);
        }
    }
    
    void Update()
    {
        for (int i = 0; i < Walls.Count; i++)
        {
            if (Walls[i].gameObject.activeInHierarchy == false)
            {
                Walls[i].gameObject.SetActive(true);
                Walls[i].transform.position = new Vector3( Random.Range(0f, 1f) + distanceBetweenWalls * WallCount, Random.Range(-0.8f, 3.8f), 0);
                WallCount++;
                return;
            }
        }
    }
}
