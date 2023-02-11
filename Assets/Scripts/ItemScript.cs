using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.Build.Content;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    bool isCollected = false;
    public ManageGame myManageGame;

    

    private void Update()
    {
        if (isCollected)
        {
            myManageGame.collectedItemAmount += 1;
            Destroy(gameObject);
        }

        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isCollected = true;
        }
    }
}
