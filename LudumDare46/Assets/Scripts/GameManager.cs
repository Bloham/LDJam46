using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI gameOverText;
    public GameObject mainMenue;
    public GameObject gameMenue;
    public GameObject gameOverMenue;
    

    public int health;
    public bool isGameActive;
    public int maxHealth = 100;
    public int plantTimer = 1;

    public bool plantIsNormal = false;
    public bool plantIsDry = false;
    public bool plantIsWet = false;
    public bool plantIsDead = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health == maxHealth && plantIsDead == false)
        {
            GameOver();
            gameOverText.text = ("Your plant got too much sunlight and dried out. I hope it will rain more next time.");
        }
        if (health == -maxHealth && plantIsDead == false)
        {
            GameOver();
            gameOverText.text = ("Your plant got too much water and drowned. I hope it will have more sunshine next time.");
        }
        if(Time.time >= plantTimer && isGameActive == true)
        {
            plantTimer = Mathf.FloorToInt(Time.time) + 1;
            AutoHealth();
        }
    }

    public void UpdateHeath(int heathToAdd)
    {
       health += heathToAdd;
       if (health >= -maxHealth/4 && health <= maxHealth/4 && plantIsNormal == false)
        {
            //Debug.Log("Plant is Normal: " + plantIsNormal);
            plantIsWet = false;
            plantIsDry = false;
            plantIsNormal = true;
            
        }
        if (health >= -maxHealth && health <= -maxHealth / 4 && plantIsWet == false)
        {
            plantIsNormal = false;
            plantIsWet = true;
            Debug.Log("Plant is Wet: " + plantIsWet);
           
            
        }
        if (health >= maxHealth/4 && health <= maxHealth && plantIsDry == false)
        {
            plantIsNormal = false;
            plantIsDry = true;
            Debug.Log("Plant is Dry: " + plantIsDry);
            
            
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        health = 0;

        //menues
        mainMenue.gameObject.SetActive(false);
        gameOverMenue.gameObject.SetActive(false);
        gameMenue.gameObject.SetActive(true);

        //plant stages
        plantIsDead = false;
        plantIsNormal = true;
        plantIsDry = false;
        plantIsWet = false;
    }
    
    private void GameOver()
    {
        isGameActive = false;

        gameOverMenue.gameObject.SetActive(true);
        gameMenue.gameObject.SetActive(false);

        Debug.Log("Plant is Dead: " + plantIsDead);
        plantIsDead = true;
        plantIsNormal = false;
        plantIsDry = false;
        plantIsWet = false;
    }

    private void AutoHealth() // This dries out or Waters the plant automatically over time
    {
        if (health >= 0)
        {
            UpdateHeath(1); 
        }
        else
        {
            UpdateHeath(-1);
        }
    }
}
