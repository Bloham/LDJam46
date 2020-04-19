using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.Find("GameManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameManager.isGameActive == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    PrintName(hit.transform.gameObject);
                }
            }
        }
    }
    private void PrintName(GameObject go)
    {
        Debug.Log(go.name);
        if (go.CompareTag("Enemy"))
        {
            Debug.Log("Ray hits: " + go);
            audioManager.PlayDestroy();
            Destroy(go);

        }
    }

}
