using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MovableMask : MonoBehaviour
{


    public GameObject moveableMask;

    public GameObject logo;
    public Image avatar;
    public Image background;
    public int isLeft;
    public bool onRight;
    public TMP_InputField inputText;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(IEStart());
    }

    IEnumerator IEStart()
    {
        background.gameObject.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.5f);
        LeanTween.scale(avatar.gameObject, new Vector3(1, 1, 1), .5f).setDelay(.5f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.scale(logo.gameObject, new Vector3(.5f, .5f, .25f), 1.5f).setDelay(.5f).setEase(LeanTweenType.easeOutBack);
        yield return new WaitForSeconds(2);
    
        LeanTween.scale(inputText.gameObject, new Vector3(1.98f, 1.98f, 1.98f), 1f).setDelay(.25f).setEase(LeanTweenType.easeOutExpo);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnSaveButtonClicked()
    {
       
        LeanTween.scale(avatar.gameObject, new Vector3(0, 0, 0), 0f).setDelay(0f).setEase(LeanTweenType.easeInBack);
        LeanTween.scale(logo.gameObject, new Vector3(0f, 0f, 0f), 0f).setDelay(0f).setEase(LeanTweenType.easeInBack);
        StartCoroutine(IEStart());

    }

}
