using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TaskSystem
{
    public class TaskSlotUI : MonoBehaviour
    {
       public Task task;
        [SerializeField] private int taskSlotIndex;
        [SerializeField] private TMP_Text TaskContent;
        [SerializeField] private TMP_Text TaskStatus;
        [SerializeField] private TMP_Text TaskGet;
        [SerializeField] private Button GetButton;
        [SerializeField] private TaskManager taskManager;

        private void Start()
        {
            TaskGet.text = "领取奖励";
            UpdateTaskSlotUI();
        }
        private void Update()
        {
            SetTaskSlot();
       
        }
        void SetTaskSlot()
        {
            task = taskManager.AcceptedTasks[taskSlotIndex];
        }


      public  void UpdateTaskSlotUI()
        {
            if(taskManager.AcceptedTasks[taskSlotIndex] == null)
            {
                TaskContent = null;
                TaskStatus = null;
                TaskGet = null;
                EnableSlotUI(false);
                return;
            }
            else
            {
                TaskContent.text = taskManager.AcceptedTasks[taskSlotIndex].taskDescription;
               switch (taskManager.AcceptedTasks[taskSlotIndex].taskStatue)
                {
                    case Task.TaskStatus.NotAccepted:
                        TaskStatus.text = "未领取任务";
                        break;
                    case Task.TaskStatus.AcceptedNotCompleted:
                        TaskStatus.text = "正在进行中";
                        break;
                    case Task.TaskStatus.CompletedNotRewarded:
                        TaskStatus.text = "已完成";
                        break;
                    case Task.TaskStatus.Rewarded:
                        TaskStatus.text = "已领取奖励";
                        break;

                }

                
                EnableSlotUI(true);

            }
        }

        public void EnableSlotUI(bool enable)
        {
           TaskContent .enabled = enable;
                TaskStatus.enabled = enable;
            TaskGet.enabled = enable;
        }
    }

   
}


