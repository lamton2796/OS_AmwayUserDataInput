using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DarkcupGames;

public class QuestionEventManager : MonoBehaviour
{
    public List<Sprite> sprBrands;

    public GameObject circle;
    public Button backButton;
    public Button startButton;
    public SpriteRenderer demoImage;

    int count;

    private void Start() {
        circle.SetActive(false);
        backButton.gameObject.SetActive(false);
        backButton.GetComponent<Image>().color = Color.clear;

        count = 0;
    }

    public void Appear() {
        startButton.gameObject.SetActive(false);
        count = count % sprBrands.Count;

        demoImage.sprite = sprBrands[count];
        circle.SetActive(true);

        int rand = Random.Range(0, 2);
        switch (rand) {
            case 0:
                StartCoroutine(IEAppear());
                break;
            case 1:
                StartCoroutine(IEAppear2());
                break;
        }

        count++;
    }

    public IEnumerator IEAppear() {
        circle.SetActive(true);
        backButton.gameObject.SetActive(false);
        demoImage.gameObject.SetActive(true);
        demoImage.color = new Color(1, 1, 1, 1);

        circle.transform.localScale = Vector2.zero;
        LeanTween.value(0f, 100f, 2f).setOnUpdate((float f) => {
            circle.transform.localScale = new Vector2(f, f);
        });

        yield return new WaitForSeconds(3f);

        backButton.gameObject.SetActive(true);
        var img = backButton.GetComponent<Image>();
        LeanTween.value(0f, 1f, 1f).setOnUpdate((float f) => {
            img.color = new Color(1, 1, 1, f);
        });
    }

    public IEnumerator IEAppear2() {
        demoImage.gameObject.SetActive(true);
        demoImage.color = new Color(1, 1, 1, 0);
        circle.transform.localScale = new Vector2(100, 100);

        LeanTween.value(0f, 1f, 1f).setOnUpdate((float f) => {
            demoImage.color = new Color(1, 1, 1, f);
        });

        yield return new WaitForSeconds(3f);

        backButton.gameObject.SetActive(true);
        var img = backButton.GetComponent<Image>();
        LeanTween.value(0f, 1f, 1f).setOnUpdate((float f) => {
            img.color = new Color(1, 1, 1, f);
        });
    }

    public void Back() {
        StartCoroutine(IEBack());
    }

    public IEnumerator IEBack() {
        backButton.gameObject.SetActive(true);
        var img = backButton.GetComponent<Image>();
        LeanTween.value(1f, 0f, 1f).setOnUpdate((float f) => {
            img.color = new Color(1, 1, 1, f);
            demoImage.color = new Color(1, 1, 1, f);
        });

        yield return new WaitForSeconds(1f);
        backButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
    }

    public void ButtonEffect(GameObject button) {
        EasyEffect.Appear(button, 1f, 1f, maxScale: 1.1f);
    }
}