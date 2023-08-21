using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    [System.Serializable]
    public struct ItemSlot 
    {
     public  Item Item;
      public int Quantity;
  
      public  ItemSlot(Item item,int Quantity )
        {
            Item = item;
            this.Quantity=Quantity;
        }
    }
}


