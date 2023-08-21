using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ItemSystem
{
    public class InventoryItemDragHandler : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
       
        private static InventorySlotUI currentSlectedUI;
        
   [SerializeField]  private static InventorySlotUI firstSlectedSlotUI;
    [SerializeField] private  static InventorySlotUI secondSlectedSlotUI;

         public   GameObject TempSlotUI;
        public Image TempSlotIcon;
        public TMP_Text TempSlotQuantity;

        public GameObject DestoryUI;
        public TMP_Text WarningText;
        public Button Destory_YES;
        public Button Destory_NO;

        void Awake()
        {
            
        }
        void Start()
        {

            TempSlotUI.SetActive(false);
         
            Destory_YES.onClick.AddListener(Destory_Yes);
            Destory_NO.onClick.AddListener(Destory_No);
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            currentSlectedUI = transform.GetComponent<InventorySlotUI>();
            if (eventData.button==PointerEventData.InputButton.Left)
            {
                if(currentSlectedUI.inventorySlot.Item==null)
                {
                    return;
                }
                currentSlectedUI.DisplayToolTip();
            }
           if(eventData.button==PointerEventData.InputButton.Right)
            {
            

                currentSlectedUI.HideToolTip();
            }
          
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            currentSlectedUI = transform.GetComponent<InventorySlotUI>();
            if (eventData.button==PointerEventData.InputButton.Left)
            {
                if (currentSlectedUI.inventorySlot.Item == null)
                {
                    return;
                }
                currentSlectedUI.HideToolTip();
                firstSlectedSlotUI = currentSlectedUI;
            }
            
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (currentSlectedUI.inventorySlot.Item == null)
                {
                    return;
                }
                TempSlotIcon.sprite = currentSlectedUI.inventorySlot.Item.Icon;
                TempSlotQuantity.text = currentSlectedUI.inventorySlot.Quantity > 1 ? currentSlectedUI.inventorySlot.Quantity.ToString() : " ";
                TempSlotUI.SetActive(true);
                currentSlectedUI.EnableSlotUI(false);
               TempSlotUI.transform.position = Input.mousePosition;
               
            }
        
         
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (eventData.pointerCurrentRaycast.gameObject != null)
                {
                    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<InventorySlotUI>() != null)
                    {
                        secondSlectedSlotUI = eventData.pointerCurrentRaycast.gameObject.GetComponent<InventorySlotUI>();
                        currentSlectedUI.inventorySlot.Inventory.ItemContainer.SwapItem
                            (currentSlectedUI.inventorySlot.InventoryIndex, secondSlectedSlotUI.inventorySlot.InventoryIndex);
                        TempSlotUI.SetActive(false);
                        currentSlectedUI.EnableSlotUI(true);
                     
                     
                    }
                    else if(eventData.pointerCurrentRaycast.gameObject.name=="BlockUI")
                    {
                        TempSlotUI.SetActive(false);
                        DestoryUI.SetActive(true);
                        WarningText.text = $"Are you sure to destory this item \"{firstSlectedSlotUI.inventorySlot.Item.name}\"";

                    }
                    else
                    {
                        TempSlotUI.SetActive(false);
                        currentSlectedUI.EnableSlotUI(true);

                    }
                }


              

            }


      
        }
       
       
        public void OnPointerEnter(PointerEventData eventData)
        {
            
            if (transform.GetComponent<InventorySlotUI>().inventorySlot.Item == null)
            {
                return;
            }
            Color color = transform.GetComponent<Image>().color;
            color.a = 1;
            eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().color = color;

          


        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Color color = transform.GetComponent<Image>().color;
            color.a = 0.7f;
            transform.GetComponent<Image>().color = color;

        }

     
        public void Destory_Yes()
        {
            currentSlectedUI.inventorySlot.Inventory.ItemContainer.RemoveAt(currentSlectedUI.inventorySlot.InventoryIndex);
            DestoryUI.SetActive(false);
            TempSlotUI.SetActive(false);
            currentSlectedUI.EnableSlotUI(true);

        }
        public void Destory_No()
        {
            DestoryUI.SetActive(false);
            TempSlotUI.SetActive(false);
               currentSlectedUI.EnableSlotUI(true);
           
        }

        
    }
}

