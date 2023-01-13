using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Globalization;
using System;
using UnityEditor.Build.Content;

public class EndingScript : MonoBehaviour
{

    public UnityEvent victoryEvent;
    public UnityEvent nonVictoryEvent;

    public ManageGame myManageGame;
    public SpriteRenderer spriteRenderer;

    public Sprite activeSprite;
    public Sprite inactiveSprite;

    private bool ended;

    void Start()
    {
        spriteRenderer.sprite = inactiveSprite;


    }

    void Update()
    {
    if(ended)
        {
            if (myManageGame.collectedItemAmount == 6)
            {
                spriteRenderer.sprite = activeSprite;
                victoryEvent.Invoke();
            }
            else
{
    nonVictoryEvent.Invoke();
}
        }
            }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag.Equals("Player"))
        {
            ended = true;            
        }
    }
}         
