using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

[System.Serializable]
public class CustomerData
{
    public string id;
    public string name;
    public string applicationDate;
    public string title;
    public string year;
}

public class LoadData : MonoBehaviour
{
    
   
    [SerializeField] TMP_InputField tmpInput;
    private string IDCustomer; 
    public List<CustomerData> data = new List<CustomerData>();
    public static List<string> lines = new List<string>();
    string[] line = new string[lines.Count];
    
    

   //   public TextMeshPro nameText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI congratulation_text;
     Dictionary<string, Sprite> bgs = new Dictionary<string,Sprite>();

    public Button saveButton;
    public Button realoadButton;
    public GameObject backgroundImage;
    public GameObject avatarImage;
    public GameObject logoImage;
    public GameObject titleImage;
    string background = "Background";
    string avatar = "Avatar";
    string logo = "Logo";
    string titleImg = "Title";
    // Start is called before the first frame update
    void Start()
    {
        ChangeBackground("Silver Producer");
        nameText.text = null;
        realoadButton.gameObject.SetActive(false);
        congratulation_text.gameObject.SetActive(false);
        titleImage.gameObject.SetActive(false);
        //// add dictionary
        //bgs.Add("Silver Producer", backgroundSprites[0]);
        //bgs.Add("Gold Producer", backgroundSprites[1]);
        //bgs.Add("Platinum", backgroundSprites[2]);
        //bgs.Add("Founders Platinum", backgroundSprites[3]);
        //bgs.Add("Ruby", backgroundSprites[4]);
        //bgs.Add("Founders Ruby", backgroundSprites[5]);
        //bgs.Add("Sapphire", backgroundSprites[6]);
        //bgs.Add("Founders Sapphire", backgroundSprites[7]);
        //bgs.Add("Emerald", backgroundSprites[8]);
        //bgs.Add("Founders Emerald", backgroundSprites[9]);
        //bgs.Add("Diamond", backgroundSprites[10]);
        //bgs.Add("Founders Diamond", backgroundSprites[11]);
        //bgs.Add("Executive Diamond", backgroundSprites[12]);
        //bgs.Add("Founders Executive Diamond", backgroundSprites[13]);
        //bgs.Add("Double Diamond", backgroundSprites[14]);
        //bgs.Add("Founders Double Diamond", backgroundSprites[15]);
        //bgs.Add("Triple Diamond", backgroundSprites[16]);
        //bgs.Add("Founders Tripple Diamond", backgroundSprites[17]);

        data = new List<CustomerData>();
        CustomerData processedData = null;
        //tsv data converted to text is an array
        string input = Resources.Load<TextAsset>("data.tsv").text;

        //fill pre created array with lines 
        line = input.Split('\n');
        for (int i = 1; i < 20; i++)
        {
            string[] items = line[i].Replace("\r", "").Split('\t');
            processedData = new CustomerData();
            for(int j = 0; i < data.Count; i++)
            {
                if(data[j].id == processedData.id)
                {
                    continue;
                }
            }


            processedData.id = items[0];
            processedData.name = items[1];
            processedData.applicationDate = items[2];
            processedData.title = items[3];
            processedData.year = items[4];
            data.Add(processedData);
        }

    }


    
    public void PressedSaveButton()
    {

        Debug.Log("press save");
        IDCustomer = tmpInput.text;
        CustomerData processedData = new CustomerData();
        congratulation_text.gameObject.SetActive(true);
        //tsv data converted to text is an array
        string input = Resources.Load<TextAsset>("data.tsv").text;

        //fill pre created array with lines 
        line = input.Split('\n');
        for (int i = 1; i < 209180 ; i++)
        {
            string[] items = line[i].Replace("\r", "").Split('\t');
            processedData.id = items[0];
            processedData.name = items[1];
            processedData.applicationDate = items[2];
            processedData.title = items[3];
            processedData.year = items[4];
            data.Add(processedData);

            if(IDCustomer==processedData.id)
            {
                //   Debug.Log(processedData.id+"\n");
                //Debug.Log(processedData.name+"\n");
                //Debug.Log(processedData.applicationDate+"\n");
                //Debug.Log(processedData.title+"\n");
                //Debug.Log(processedData.year);

                nameText.text = processedData.name;
                ChangeBackground(processedData.title);
                break;

               
            }
             // Debug.Log(processedData.id);
            
        }
        InvisibleUI();
        //  Debug.Log(data[1000].id); 


    }
    
    public void ChangeBackground(string title)
    {
        backgroundImage.GetComponent<Image>().sprite = Resources.Load<Sprite>($"{title}/" + background); 
        avatarImage.GetComponent<Image>().sprite = Resources.Load<Sprite>($"{title}/" + avatar);
        logoImage.GetComponent<Image>().sprite = Resources.Load<Sprite>($"{title}/" + logo);
        titleImage.GetComponent<Image>().sprite = Resources.Load<Sprite>($"{title}/" + titleImg);
        titleImage.gameObject.SetActive(true);
    }

    public void InvisibleUI()
    {
        saveButton.gameObject.SetActive(false);
        tmpInput.gameObject.SetActive(false);
        realoadButton.gameObject.SetActive(true);

    }
    public void ReloadButton()
    {
        ChangeBackground("Silver Producer");
        congratulation_text.gameObject.SetActive(false);
        titleImage.gameObject.SetActive(false);
        nameText.text = null;
        tmpInput.text = "Enter customer ID";
        tmpInput.contentType = TMP_InputField.ContentType.Standard;

        tmpInput.ForceLabelUpdate();
        saveButton.gameObject.SetActive(true);
        tmpInput.gameObject.SetActive(true);
        realoadButton.gameObject.SetActive(false);
    }
    
}
