using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TimeSystem
{
    public class TimeManager : MonoBehaviour
    {

        public TMP_Text  seasonText;
        public TMP_Text yearMonthText;
        public TMP_Text dayHourMinuteText;

        public     GameObject SpringMap;
        public GameObject SummerMap;
        public GameObject AutumMap;
        public GameObject WinterMap;



        private void Awake()
        {
            
        }
        void Start()
        {
            
            
        }


        void Update()
        {
            yearMonthText.text = $"{GameTime.Year} 年{GameTime.Month} 月";
            dayHourMinuteText.text = $"{GameTime.Day} 日  {GameTime.Hour} 小时  {GameTime.Minute} 分钟";
                
            
        }

     

        public void ChangeSeason(int currentSeason )
        {
            
            switch(currentSeason)
            {
                case 0: 
                    SpringMap.SetActive(true);
                    SummerMap.SetActive(false);
                    AutumMap.SetActive(false);
                    WinterMap.SetActive(false);
                    seasonText.text = "春天";

                        break;
                case 1:
                    SpringMap.SetActive(false);
                    SummerMap.SetActive(true);
                    AutumMap.SetActive(false);
                    WinterMap.SetActive(false);
                    seasonText.text = "夏天";

                    break;
                case 2:
                    SpringMap.SetActive(false);
                    SummerMap.SetActive(false);
                    AutumMap.SetActive(true);
                    WinterMap.SetActive(false);
                    seasonText.text = "秋天";

                    break;
                case 3:
                    SpringMap.SetActive(false);
                    SummerMap.SetActive(false);
                    AutumMap.SetActive(false);
                    WinterMap.SetActive(true);
                    seasonText.text = "冬天";
                 

                    break;


            }



        }


    }
}

