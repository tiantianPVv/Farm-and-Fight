using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    public interface IItemContainer
    {
        ItemSlot AddItem(ItemSlot itemSlot);
        void RemoveItem(ItemSlot itemSlot);
        void RemoveAt(int itemIndex);
        void SwapItem(int itemIndexOne, int itemIndexTwo);
        bool HasItem(Item item);
        ItemSlot GetSlotByIndex(int SlotIndex);
        int GetTotalQuantity(Item Item);


    }
}

