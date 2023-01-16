using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
    public int collectedItemAmount;
    bool gameHasEnded = false;
    public Text pagesText;
    public CanvasGroup endingCanvasGroup;
    public CanvasGroup victoryCanvasGroup;
    public CanvasGroup nonvictoryCanvasGroup;

    public void Start()
    {
        collectedItemAmount = 0;
        hideCanvasGroup(endingCanvasGroup);
        hideCanvasGroup(victoryCanvasGroup);
        hideCanvasGroup(nonvictoryCanvasGroup);
    }

    public void Update()
    {
        pagesText.text = Convert.ToString(collectedItemAmount);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            UnityEngine.Debug.Log("GAME OVER");
            showCanvasGroup(endingCanvasGroup);
        }
        
    }

    public void WinGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            UnityEngine.Debug.Log("Victory!");
            showCanvasGroup(victoryCanvasGroup);
        }
    }

    public void NowinGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            UnityEngine.Debug.Log("Nonvictory");
            showCanvasGroup(nonvictoryCanvasGroup);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
        UnityEngine.Debug.Log("Load level 1");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        UnityEngine.Debug.Log("Load main menu");
    }

    void hideCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    void showCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}
