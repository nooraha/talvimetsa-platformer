using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CanvasGroup menuCanvasGroup;
    public CanvasGroup controlsCanvasGroup;
    public CanvasGroup storyCanvasGroup;

    private void Start()
    {
        showCanvasGroup(menuCanvasGroup);
        hideCanvasGroup(storyCanvasGroup);
        hideCanvasGroup(controlsCanvasGroup);
    }

    public void GoToTitle()
    {
        showCanvasGroup(menuCanvasGroup);
        hideCanvasGroup(storyCanvasGroup);
        hideCanvasGroup(controlsCanvasGroup);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
        UnityEngine.Debug.Log("Load level 1");
    }

    public void ShowControls()
    {
        showCanvasGroup(controlsCanvasGroup);
        hideCanvasGroup(menuCanvasGroup);
    }

    public void ShowStory()
    {
        showCanvasGroup(storyCanvasGroup);
        hideCanvasGroup(menuCanvasGroup);
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
