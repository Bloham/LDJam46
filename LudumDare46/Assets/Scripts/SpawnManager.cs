using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fly;
    public GameObject[] spawnPoints;

    private GameManager gameManager;

    public float startDelay;
    public float spawnInterval;

    private int spawnNr;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnFlys", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnFlys()
    {
        if (gameManager.isGameActive == true)
        {
            Instantiate(fly, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, fly.transform.rotation);
        }
    }
}
