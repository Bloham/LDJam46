using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI healthText;
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
        if (health == maxHealth)
        {
            GameOver();
            gameOverText.text = ("Your plant got too much sunlight and dried out. I hope it will rain more next time.");
        }
        if (health == -maxHealth)
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
       healthText.text = ("" + health);
       if (health >= -maxHealth/2 && health <= maxHealth/2)
        {
            Debug.Log("Plant is Normal: " + plantIsNormal);
            plantIsNormal = true;
            plantIsWet = false;
            plantIsDry = false;
        }
        if (health >= -maxHealth && health <= -maxHealth / 2)
        {
            Debug.Log("Plant is Wet: " + plantIsWet);
            plantIsWet = true;
        }
        if (health >= maxHealth/2 && health <= maxHealth)
        {
            Debug.Log("Plant is Dry: " + plantIsDry);
            plantIsDry = true;
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
        healthText.text = ("0");

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
