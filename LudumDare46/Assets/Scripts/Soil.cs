using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{

    // Got a little help for changing the textures of the soil https://www.youtube.com/watch?v=dJB07ZSiW7k
    private GameManager gameManager;
    public Material[] material;
    Renderer rend;
    private Material current;

    public float transitionTime = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.plantIsNormal)
        {
            rend.sharedMaterial.Lerp(rend.sharedMaterial, material[0], transitionTime);
        }
        if (gameManager.plantIsDry)
        {
            rend.sharedMaterial.Lerp(rend.sharedMaterial, material[1], transitionTime);
        }
        if (gameManager.plantIsWet)
        {
            rend.sharedMaterial.Lerp(rend.sharedMaterial, material[2], transitionTime);
        }
        if (gameManager.plantIsDead)
        {
            rend.sharedMaterial.Lerp(rend.sharedMaterial, material[3], transitionTime);
        }
    }
}
