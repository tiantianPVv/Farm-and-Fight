using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaskSystem
{
    public class TaskManager : MonoBehaviour
    {
      public   List<Task> unAcceptedTasks=new List<Task>();
      public List<Task> AcceptedTasks = new List<Task>();

       
        private void Update()
        {
         
        }
        
        void AcceptTask(Task task)
        {
            if(task.taskStatue==Task.TaskStatus.AcceptedNotCompleted)
            {
                unAcceptedTasks.Remove(task);
                AcceptedTasks.Add(task);
            }
               

        }

   
     public   void CheckCollectTask(int id)
        {
            foreach (Task task in AcceptedTasks)
            {
                if(task.TaskClass==Task.TaskClasses.CollectTask&&task.GoalID==id)
                {
                    task.currentProgress++;
                }
                if(task.currentProgress==task.GoalProgress)
                {
                    FinishTask(task);
                }
            }

        }

 
      public  void CheckFightTask(int id)
        {
            foreach (Task task in AcceptedTasks)
            {
                if (task.TaskClass == Task.TaskClasses.FightTask && task.GoalID == id)
                {
                    task.currentProgress++;
                }
                if (task.currentProgress == task.GoalProgress)
                {
                    FinishTask(task);
                }
            }

        }

  
      public  void CheckTalkTask(int id)
        {
            foreach (Task task in AcceptedTasks)
            {
                if (task.TaskClass == Task.TaskClasses.TalkTask && task.GoalID == id)
                {
                    task.currentProgress++;
                }
                if (task.currentProgress == task.GoalProgress)
                {
                    FinishTask(task);
                }
            }

        }


        void FinishTask(Task task)
        {
            task.taskStatue = Task.TaskStatus.CompletedNotRewarded;
            for (int i = 0; i < task.Rewards.Count; i++)
            {
                GameManager.Instance.PlayerInventory.ItemContainer.AddItem(task.Rewards[i]);
            }
          
         
        }

    }
}

