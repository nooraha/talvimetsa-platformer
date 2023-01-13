using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageGame : MonoBehaviour
{
    public int collectedItemAmount;

    public Text pagesText;

    public void Start()
    {
        collectedItemAmount = 0;
    }

    public void Update()
    {
        pagesText.text = Convert.ToString(collectedItemAmount);
    }
}
