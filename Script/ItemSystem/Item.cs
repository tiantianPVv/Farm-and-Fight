using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
    public class Item : ScriptableObject
    {
       [SerializeField] private string itemname;
       [SerializeField] private Sprite icon;
       [SerializeField]private string shortToolTip;
        [TextArea][SerializeField] private string detailToolTip;
       [SerializeField]private int maxStack;
        public string ItemName => ItemName;
        public Sprite Icon =>icon;
       
        public int MaxStack => maxStack;

        public string ShortToolTip => shortToolTip; 
        public string DetailToolTip => detailToolTip;
    }

}
