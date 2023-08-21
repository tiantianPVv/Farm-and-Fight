using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace ItemSystem
{
    public class InventorySlotUI : MonoBehaviour
    {
       public InventorySlot inventorySlot;
        
        public Image ItemIcon;
        public TMP_Text ItemQuantity;

        public GameObject ToolTipUI;
        public TMP_Text ToolTipText;
        private void OnEnable()
        {
            UpdateSlotUI();
            ToolTipUI.SetActive(false);
        }

        private void Start()
        {
            UpdateSlotUI();
            SetAlpha();
            
        }
     
        private void Update()
        {
            SetInventorySlot();
        }
       
        public void UpdateSlotUI()
        {
            
            if (inventorySlot.Inventory.ItemContainer.GetSlotByIndex(inventorySlot.InventoryIndex).Item == null)
            {
                ItemIcon.sprite = null;
                ItemQuantity.text = null;
                EnableSlotUI(false);
                return;
            }
            ItemIcon.sprite = inventorySlot.Inventory.ItemContainer.GetSlotByIndex(inventorySlot.InventoryIndex).Item.Icon;
            ItemQuantity.text = inventorySlot.Inventory.ItemContainer.GetSlotByIndex(inventorySlot.InventoryIndex).Quantity > 1 ?
                inventorySlot.Inventory.ItemContainer.GetSlotByIndex(inventorySlot.InventoryIndex).Quantity.ToString() : "";


            EnableSlotUI(true);


        }

        public void EnableSlotUI(bool enable)
        {
            ItemIcon.enabled = enable;
            ItemQuantity.enabled = enable;
        }
        private void SetInventorySlot()
        {
            inventorySlot.Item = inventorySlot.Inventory.ItemContainer.GetSlotByIndex(inventorySlot.InventoryIndex).Item;
            inventorySlot.Quantity = inventorySlot.Inventory.ItemContainer.GetSlotByIndex(inventorySlot.InventoryIndex).Quantity;

        }
        public void DisplayToolTip()
        {
            ToolTipText.text = inventorySlot.Item.DetailToolTip;
            ToolTipUI.SetActive(true);

        }
        public void HideToolTip()
        {
            ToolTipUI.SetActive(false);
        }


        void SetAlpha()
        {
            Color color = transform.GetComponent<Image>().color;
            color.a = 0.7f;
            transform.GetComponent<Image>().color=color;

        }

    }
}

