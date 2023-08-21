using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

namespace ItemSystem
{
   

        [CreateAssetMenu(fileName = "New Inventory", menuName = "Items/Inventory")]
   
        public class Inventory : ScriptableObject
        {
     
            [SerializeField] private VoidEvent OnInventoryItemUpdated;
        public ItemSlot testItemSlot=new ItemSlot();


        //定义一个只读属性，并将实例对象赋值给属性
        public ItemContainer ItemContainer= new ItemContainer(20);
      
        private void OnEnable()
            {
                ItemContainer.OnItemUpdated += OnInventoryItemUpdated.Raise;

            }
            private void OnDisable()
            {
                ItemContainer.OnItemUpdated -= OnInventoryItemUpdated.Raise;
            }
        [ContextMenu("Test Add")]
        public void TestAdd()
        {
            ItemContainer.AddItem(testItemSlot);
        }
    }
    
}


