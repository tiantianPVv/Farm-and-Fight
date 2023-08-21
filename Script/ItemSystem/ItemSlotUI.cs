using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ItemSystem
{
    public class ItemSlotUI : MonoBehaviour
    {
       [SerializeField] private ItemSlot itemSlot;
        public Image ItemIcon;
        public TMP_Text ItemQuantity;
        public GameObject ToolTipUI;
        public TMPro.TextMeshPro ToolTip;
        public ItemSlot ItemSlot=>itemSlot;

        protected void DisplayToolTip()
        {
            
            ToolTip.text = itemSlot.Item.ShortToolTip;
            ToolTipUI.SetActive(true);

        }
    }
}

