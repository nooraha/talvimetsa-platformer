using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Globalization;
using System;

public class Death : MonoBehaviour
{
    [SerializeField] private bool dead = false;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private int lives;

    public CharaMovement charaMovement;

    public Text livesText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Deadly")
        {
            dead = true;
        }

        if (collision.tag == "Checkpoint")
        {
            respawnPoint = collision.transform;
        }
    }

    void Start()
    {
        lives = 5;
    }

    private void Update()
    {
        //death anim and respawn
        if (dead == true)
        {
            dead = false;
            lives -= 1;
            Respawn();
        }

        if (lives == 0)
        {
            charaMovement.canMove = false;
            FindObjectOfType<ManageGame>().EndGame();
        }

        livesText.text = Convert.ToString(lives);

        
    }

    private void Respawn()
    {
        //get reversed and make it false
        /* GameObject player = GameObject.Find("Player");
        CharaMovement charaMovement = player.GetComponent<CharaMovement>();
        charaMovement.reversed = false; */

        //play death animation
        transform.localPosition = new Vector3(respawnPoint.position.x, respawnPoint.position.y, 1);
        //play respawn anim

        
    }
}
