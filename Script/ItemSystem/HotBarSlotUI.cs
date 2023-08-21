using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace ItemSystem
{
    public class HotBarSlotUI : MonoBehaviour
    {
        public HotBarSlot hotBarSlot;
        public Image ItemIcon;
        public TMP_Text ItemQuantity;
        public GameObject ToolTipUI;
        public TMP_Text ToolTipText;

        [SerializeField] private Inventory Inventory;

        private void OnEnable()
        {
            UpdateSlotUI();
            ToolTipUI.SetActive(false);
        }

        private void Start()
        {
            UpdateSlotUI();
        }
        private void Update()
        {
            SetHotBarSlot();

        }

        public void UpdateSlotUI()
        {
            if (Inventory.ItemContainer.GetSlotByIndex(hotBarSlot.InventoryIndex).Item == null)
            {
                ItemIcon.sprite = null;
                ItemQuantity.text = null;
                EnableSlotUI(false);
                return;
            }

            ItemIcon.sprite =Inventory.ItemContainer.GetSlotByIndex(hotBarSlot.InventoryIndex).Item.Icon;
            ItemQuantity.text = Inventory.ItemContainer.GetSlotByIndex(hotBarSlot.InventoryIndex).Quantity > 1 ?
                Inventory.ItemContainer.GetSlotByIndex(hotBarSlot.InventoryIndex).Quantity.ToString() : " ";
            EnableSlotUI(true);
        }

        private void EnableSlotUI(bool enable)
        {
            ItemIcon.enabled = enable;
            ItemQuantity.enabled = enable;
        }


        private void SetHotBarSlot()
        {
            hotBarSlot.Item=Inventory.ItemContainer.GetSlotByIndex(hotBarSlot.InventoryIndex).Item;
            hotBarSlot.Quantity = Inventory.ItemContainer.GetSlotByIndex(hotBarSlot.InventoryIndex).Quantity;
        }
        public void DisplayToolTip()
        {
            ToolTipText.text = hotBarSlot.Item.DetailToolTip;
            ToolTipUI.SetActive(true);

        }
        public void HideToolTip()
        {
            ToolTipUI.SetActive(false);
        }
    }
}
