using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStages : MonoBehaviour
{
    private GameManager gameManager;
    private Transform target;
    private float speed = 2f;
    private Vector3 speedRot = Vector3.right * 50f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = GameObject.FindGameObjectWithTag("Plant").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedRot * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    
}
