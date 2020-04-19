using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Transform plant;
    private GameManager gameManager;

    private Transform target;
    public float speed = 2f;
    private Vector3 speedRot = Vector3.right * 50f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = GameObject.FindGameObjectWithTag("Plant").transform;
    }

    void Update()
    {
        
        
        if (gameManager.isGameActive == true)
        {
            transform.Rotate(speedRot * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plant") && gameManager.plantIsDead == false) 
        {
            gameManager.GameOver();
            gameManager.gameOverText.text = ("The Fly got you! Try to protect your plant from these flying plant eater!");
        }
    }
}
