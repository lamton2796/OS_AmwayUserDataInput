using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DarkcupGames;

public class LogoButtonController : MonoBehaviour
{
    public int index;
    public int pressedTime;
    public TextMeshProUGUI textPress;
    public GameObject heartEffect; 

    public void Pressed()
    {
     GameObject eff =   Instantiate(heartEffect, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Destroy(eff, 2f);
        pressedTime++;
        EasyEffect.Appear(gameObject, 1f, 1f, maxScale: 1.1f);
        UpdateDisplay();

        GameSystem.userdata.brandLikeCounts[index] = pressedTime;
    }

    public void UpdateDisplay() {
        textPress.text = pressedTime.ToString();
    }
}