using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OnEnableOBject : MonoBehaviour
{
    public TextMeshProUGUI congrats_text;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnSaveButtonClicked()
    {
        if (!this.gameObject.activeSelf)
            this.gameObject.SetActive(true);
        StartCoroutine(IEOnSaveButtonClicked());
    }
    IEnumerator IEOnSaveButtonClicked()
    {
        yield return new WaitForSeconds(.5f);
        LeanTween.scale(congrats_text.gameObject, new Vector3(1, 1, 1), 1f).setDelay(.5f).setEase(LeanTweenType.easeOutBack);

        yield return new WaitForSeconds(3f);
 
        LeanTween.scale(this.gameObject, new Vector3(1, 1, 1), 1f).setDelay(.5f).setEase(LeanTweenType.easeOutCubic);

    }

    public void OnReloadButtonClicked()
    {
        congrats_text.gameObject.SetActive(false);
        LeanTween.scale(congrats_text.gameObject, new Vector3(0, 0, 0), .1f).setDelay(0.1f).setEase(LeanTweenType.easeInBack);
        this.gameObject.SetActive(false);
        LeanTween.scale(this.gameObject, new Vector3(0,0, 0), .1f).setDelay(0.1f).setEase(LeanTweenType.easeInBack);
    }
    
}
