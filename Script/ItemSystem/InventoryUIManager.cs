using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject HotBarUI;
    public GameObject DestoryUI;
    public GameObject BlockUI;

    private void Start()
    {
        InventoryUI.SetActive(false);
        DestoryUI.SetActive(false);
        BlockUI.SetActive(false);
    }

    private void Update()
    {
        OpenInventory();
        ManageWindows();
    }

    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (InventoryUI.activeSelf == false)
            {
                InventoryUI.SetActive(true);
            }
            else
            {
                InventoryUI.SetActive(false);
            }
        }
    }


    void  ManageWindows()
    {
        
        if(DestoryUI.activeSelf==true)
        {
            DestoryUI.transform.SetAsLastSibling();
            BlockUI.transform.SetSiblingIndex(DestoryUI.transform.GetSiblingIndex() -1);
      
        }
        else    if(InventoryUI.activeSelf==true)
        {
           
            BlockUI.SetActive(true);
            BlockUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
            BlockUI.GetComponent<CanvasGroup>().alpha = 0.5F;
            InventoryUI.transform.SetAsLastSibling();
            HotBarUI.transform.SetAsFirstSibling();
        }
     

    }
}
