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


        //����һ��ֻ�����ԣ�����ʵ������ֵ������
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


