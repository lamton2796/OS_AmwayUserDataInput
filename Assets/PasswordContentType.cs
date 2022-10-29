using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PasswordContentType : MonoBehaviour
{
    public TMP_InputField password;
    public Button submitBtn;
    // Start is called before the first frame update
    void Start()
    {
        submitBtn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDataInput()
    {
        if (!submitBtn.gameObject.activeSelf)
        {
            submitBtn.gameObject.SetActive(true);
        }
        password.contentType = TMP_InputField.ContentType.Password;
        password.ForceLabelUpdate();
    }

    public void OnDeselect()
    {

    }
}
