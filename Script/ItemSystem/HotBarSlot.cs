
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    [System.Serializable]
    public struct HotBarSlot
    {
        public Item Item;
        public int Quantity;


        [SerializeField] private int inventoryIndex;


        public int InventoryIndex => inventoryIndex;
     


    }



}



