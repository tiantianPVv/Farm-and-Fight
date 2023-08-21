using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TaskSystem
{
    [CreateAssetMenu(fileName = "NewTask", menuName = "Tasks/NewTasks")]
    public class Task : ScriptableObject
    {
        
    [SerializeField]private string taskName;
        public string TaskName
        {
            get { return taskName; }
        }


        [SerializeField] private int taskID;
        public int TaskID
        {
            get { return taskID; }
        }


     [TextArea] public string taskDescription;


        public enum TaskClasses
        {
           TalkTask,
           FightTask,
           CollectTask
        }
        [SerializeField] private TaskClasses taskClass;
        public TaskClasses TaskClass
        {
            get { return taskClass; }
        }


        public enum TaskTypes
        {
            MainTask,
            SideTask,
            DailyTask
        }
        [SerializeField] private TaskTypes taskType;
        public TaskTypes TaskType
            {
            get { return taskType; }
             }   


        public enum TaskStatus
        {
            NotAccepted,
            AcceptedNotCompleted,
            CompletedNotRewarded,
            Rewarded
        }
      public  TaskStatus taskStatue;


        [SerializeField] private int goalID;
        public int GoalID
        {
            get { return goalID; }
        }

        public int currentProgress;

        [SerializeField] private int goalProgress;
        public int GoalProgress
        {
            get { return goalProgress; }
        }

        public bool taskFinshed;

        [Header("Rewards")]
  
       private List< ItemSystem.ItemSlot> rewards;

        public List<ItemSystem.ItemSlot> Rewards
        {
            get { return rewards; }
        }

        

    }
}

