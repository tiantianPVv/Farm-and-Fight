using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem
{
    public class ItemContainer : IItemContainer
    {
       

       [SerializeField] private ItemSlot[] itemSlots = new ItemSlot[0];

            public Action OnItemUpdated = delegate { };

            public ItemContainer(int size) => itemSlots = new ItemSlot[size];


            public ItemSlot AddItem(ItemSlot itemSlot)
            {

                for (int i = 0; i < itemSlots.Length; i++)
                {
                    if (itemSlots[i].Item != null)
                    {
                        if (itemSlots[i].Item == itemSlot.Item)
                        {
                            int itemSlotRemainingSpace = itemSlots[i].Item.MaxStack - itemSlots[i].Quantity;
                            if (itemSlot.Quantity > itemSlotRemainingSpace)
                            {
                                itemSlot.Quantity -= itemSlotRemainingSpace;
                                itemSlots[i].Quantity = itemSlots[i].Item.MaxStack;
                            }
                            else
                            {
                                itemSlots[i].Quantity += itemSlot.Quantity;
                                itemSlot.Quantity = 0;
                                OnItemUpdated.Invoke();
                                return itemSlot;
                            }
                        }
                    }
                }

                for (int j = 0; j < itemSlots.Length; j++)
                {
                    if (itemSlots[j].Item == null)
                    {
                        if (itemSlot.Quantity > itemSlot.Item.MaxStack)
                        {
                            itemSlots[j] = new ItemSlot(itemSlot.Item, itemSlot.Item.MaxStack);
                            itemSlot.Quantity -= itemSlot.Item.MaxStack;
                        }
                        else
                        {
                            itemSlots[j] = new ItemSlot(itemSlot.Item, itemSlot.Quantity);
                            itemSlot.Quantity = 0;
                            OnItemUpdated.Invoke();
                            return itemSlot;
                        }
                    }
                }
                OnItemUpdated.Invoke();
                return itemSlot;
            }



            public void RemoveItem(ItemSlot itemSlot)
            {
                for (int i = 0; i < itemSlots.Length; i++)
                {
                    if (itemSlots[i].Item == itemSlot.Item)
                    {
                        if (itemSlots[i].Quantity < itemSlot.Quantity)
                        {
                            itemSlot.Quantity -= itemSlots[i].Quantity;
                            itemSlots[i] = new ItemSlot();

                        }
                        else
                        {
                            itemSlots[i].Quantity -= itemSlot.Quantity;
                            if (itemSlots[i].Quantity == 0)
                            {
                                itemSlots[i] = new ItemSlot();
                            }
                            itemSlot.Quantity = 0;
                            OnItemUpdated.Invoke();
                            return;
                        }
                    }
                }


            }


            public void RemoveAt(int slotIndex)
            {
                if (slotIndex < 0 || slotIndex > itemSlots.Length - 1)
                    return;
                itemSlots[slotIndex] = new ItemSlot();
                OnItemUpdated.Invoke();
            }


            public bool HasItem(Item item)
            {
                foreach (ItemSlot itemSlot in itemSlots)
                {
                    if (itemSlot.Item == item)
                        return true;

                }
                return false;
            }


            public void SwapItem(int itemIndexOne, int itemIndexTwo)
            {
                ItemSlot firstSlot = itemSlots[itemIndexOne];
                ItemSlot secondSlot = itemSlots[itemIndexTwo];

                if (firstSlot.Equals(secondSlot))
                    return;
                if (secondSlot.Item != null)
                {
                    if (firstSlot.Item == secondSlot.Item)
                    {
                        int secondSlotRemainingSpace = secondSlot.Item.MaxStack - secondSlot.Quantity;
                        if (firstSlot.Quantity <= secondSlotRemainingSpace)
                        {
                            itemSlots[itemIndexTwo].Quantity += firstSlot.Quantity;
                            itemSlots[itemIndexOne] = new ItemSlot();

                        }
                    else
                    {
                        itemSlots[itemIndexTwo].Quantity = itemSlots[itemIndexTwo].Item.MaxStack;
                        itemSlots[itemIndexOne].Quantity -= secondSlotRemainingSpace;
                    }

                        OnItemUpdated.Invoke();
                        return;

                    }

                }

                itemSlots[itemIndexOne] = secondSlot;
                itemSlots[itemIndexTwo] = firstSlot;

                OnItemUpdated.Invoke();
            }

            public ItemSlot GetSlotByIndex(int SlotIndex)
            {
                return itemSlots[SlotIndex];
            }

            public int GetTotalQuantity(Item item)
            {
                int totalCount = 0;

                foreach (ItemSlot itemSlot in itemSlots)
                {

                    if (itemSlot.Item == item)
                    {
                        totalCount += itemSlot.Quantity;
                    }
                }
                return totalCount;

            }




        }
    }


