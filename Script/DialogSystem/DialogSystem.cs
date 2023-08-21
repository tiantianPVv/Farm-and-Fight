using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{

    [Header("UI Component")]
    [SerializeField] private GameObject DialogBox;
    [SerializeField] private Image faceImage;
    [SerializeField] private TMP_Text dialogText;
    
   
    private int index;
    [SerializeField] float displaySpeed;
    [Header("Head Portrait")]
    [SerializeField]private Sprite headPortarit_A;
    [SerializeField] private Sprite headPortarit_B;
    bool Dialoging;
    bool isDisplaying;
    private static List<string> textlist=new List<string>();

    private void Start()
    {
        DialogBox.SetActive(false);
    }
    void Update()
    {
        if(Dialoging==false)
        {
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.Space)&& isDisplaying==false)
        {
            if (index == textlist.Count)
            {
                Dialoging = false;
                DialogBox.SetActive(false);
                return;
            }
            StartCoroutine(DisplayText());

        }
    }
    private void GetTextFromFile(TextAsset textAsset)
    {
        textlist.Clear();
        var lineData=textAsset.text.Split("\r\n");
        textlist = lineData.ToList();

    }
    IEnumerator DisplayText()
    {
        dialogText.text="";
        isDisplaying = true;

        switch(textlist[index])
        {
            case "A":
                faceImage.sprite = headPortarit_A;
                index++;
                break;
            case "B":
                faceImage.sprite = headPortarit_B;
                index++;
                break;
        }
        for(int i = 0; i < textlist[index].Length; i++)
        {
            dialogText.text += textlist[index][i];
            yield return new WaitForSeconds(1/displaySpeed);
        }
        isDisplaying = false;
        index++;
    }

  public void ExcuteDialog(TextAsset dialog)
    {
        DialogBox.SetActive(true);
        index = 0;
        Dialoging = true;
       
        GetTextFromFile(dialog);

        StartCoroutine(DisplayText());

    }
}
