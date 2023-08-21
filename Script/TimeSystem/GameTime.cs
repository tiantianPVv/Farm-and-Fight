using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeSystem
{
    public class GameTime : MonoBehaviour
    {
        //��ʵ 0.5s ��Ӧ��Ϸ 1����
        const float TimetoRealMinute = 0.5f;
        //�����ʱ��ʵ��0.5s��
        private float Timer;
        //    0.5s  1min
        //    30s   1h
        //12min 1day
        //    6h      1 month
        //    72h    1 year


        public static int Minute { get; private set; }
        public static int Hour { get; private set; }
        public static int Day { get; private set; }
        public static int Month { get; private set; }
        public static int Year { get; private set; }

        //����
        public     enum Season
        {
            Spring=0,
            Summer=1,
            Autumn=2,
            Winter=3
        }

        public Season currentSeaon;

      [SerializeField]private  EventSystem.IntEvent OnSeasonChanged;

        private void Awake()
        {
            Timer = TimetoRealMinute;
            Minute =0;
            Hour = 0;
            Day = 0;
            Month = 0;
            Year = 0;
            currentSeaon = Season.Winter;
            OnSeasonChanged.Raise((int)currentSeaon);
        }
        

        private void Update()
        {
            SetTime();
        }

        private void SetTime()
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Minute++;
                //���Ӹı��¼�
                //OnMinuteChanged.Raise(Minute);
                Timer = TimetoRealMinute;
            }
            if (Minute >= 60)
            {
                Hour++;
                //OnHourChanged(Hour);
                Minute = 0;
            }
            if (Hour >= 24)
            {
                Day++;
                //OnDayChanged(Day);
                Hour = 0;
            }
            if (Day >= 30)
            {
                Month++;
                //OnMonthChanged(Month);
                Day = 0;
               

            }
            if (Month >= 12)
            {
                Year++;
                //OnYearChanged(Year);
                Month = 0;
            }
            switch (Month + 1)
            {
                case 3:
                case 4:
                case 5:
                    currentSeaon = Season.Spring;
                    OnSeasonChanged.Raise((int)currentSeaon);
                    break;
                case 6:
                case 7:
                case 8:
                    currentSeaon = Season.Summer;
                    OnSeasonChanged.Raise((int)currentSeaon);
                    break;

                case 9:
                case 10:
                case 11:
                    currentSeaon = Season.Autumn;
                    OnSeasonChanged.Raise((int)currentSeaon);
                    break;

                case 12:
                case 1:
                case 2:
                    currentSeaon = Season.Winter;
                    OnSeasonChanged.Raise((int)currentSeaon);
                    break;
                default: break;
            }
        }


        public void DayTest()
        {
            Day++;
        }
        public void MonthTest()
        {
            Month++;
        }
        public void YearTest()
        {
            Year++;
        }
    }
}

