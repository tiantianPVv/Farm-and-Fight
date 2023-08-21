
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    [System. Serializable]
    public struct InventorySlot 
    {
        public  Item Item;
        public int Quantity;

      
        [SerializeField]private Inventory inventory;
       [SerializeField] private int inventoryIndex;


        public int InventoryIndex => inventoryIndex;
        public Inventory Inventory => inventory;


    }



}


