using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator playerAnim;
    private GameManager gameManager;

    private bool isdead = false;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if (gameManager.plantIsNormal)
        {
            isdead = false;
            Normal();
        }
       if (gameManager.plantIsDry)
        {
            GetSun();
        }
       if (gameManager.plantIsWet)
        {
            GetWet();
        }
        if (gameManager.plantIsDead && isdead == false)
        {
            isdead = true;
            Dead();
        }
    }

    private void GetWet()
    {
        playerAnim.SetBool("Normal", false);
        playerAnim.SetBool("Sun", true);
        Debug.Log("Animation Get Wet");
    }

    private void GetSun()
    {
        playerAnim.SetBool("Normal", false);
        playerAnim.SetBool("Water", true);
        Debug.Log("Animation Get Sun");
    }

    private void Normal()
    {
        playerAnim.SetBool("Dead", false);
        playerAnim.SetBool("Sun", false);
        playerAnim.SetBool("Water", false);
        playerAnim.SetBool("Normal", true);
        Debug.Log("Animation Normal");
    }

    private void Dead()
    {
        playerAnim.SetBool("Normal", false);
        playerAnim.SetBool("Sun", false);
        playerAnim.SetBool("Water", false);
        playerAnim.SetBool("Dead", true);

        Debug.Log("Animation DEAD");
    }
}
