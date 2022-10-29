using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DarkcupGames;

public class EventLikeManager : MonoBehaviour
{
    public List<Sprite> sprites;
    public List<LogoButtonController> buttons;

    private void Awake() {
        GameSystem.LoadUserData();    
        if (GameSystem.userdata.brandLikeCounts == null) {
            GameSystem.userdata.brandLikeCounts = new List<int>();
        }

        if (GameSystem.userdata.brandLikeCounts.Count != buttons.Count) {
            GameSystem.userdata.brandLikeCounts = new List<int>();
            for (int i = 0; i < buttons.Count; i++) {
                GameSystem.userdata.brandLikeCounts.Add(0);
            }
        }

        for (int i = 0; i < buttons.Count; i++) {
            buttons[i].index = i;
            buttons[i].GetComponent<Image>().sprite = sprites[i];
            buttons[i].pressedTime = GameSystem.userdata.brandLikeCounts[i];
            buttons[i].UpdateDisplay();
        }
    }

    private void Start() {
        InvokeRepeating(nameof(SaveData), 0f, 1f);
    }

    void SaveData() {
        GameSystem.SaveUserDataToLocal();
    }
}