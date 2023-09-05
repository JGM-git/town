using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class Clock
    {
        public int year;
        public int month;
        public int day;
        public int hour;
        public int minute;
    }

    /// <summary>
    /// SYSTEM VARIABLES
    /// </summary>
    
    [Header ("System Variables")]
    public Clock clock;
    [SerializeField]
    private float time = 0f;
    private UIManager ui;
    public TalkManager talkManager;
    private bool isTalking = false;
    public int talkingIndex = 0;

    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>

    void Awake()
    {
        clock = new Clock {
            year = 2023,
            month = 8,
            day = 7,
            hour = 12,
            minute = 0
        };
    }

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        talkManager = GetComponent<TalkManager>();
    }

    void Update()
    {
        time += Time.deltaTime * 100f;
        if(time >= 60f)
        {
            time = 0f;
            ManageClock();
        }
    }

    /// <summary>
    /// TIME MANAGEMENT
    /// </summary>

    private void ManageClock()
    {
        clock.minute++;

        if(clock.minute >= 60)
        {
            clock.hour++;
            clock.minute = 0;
        }

        if(clock.hour >= 24)
        {
            clock.day++;
            clock.hour = 0;
        }

        if(clock.day > GetLastDayOfMonth(clock.year, clock.month))
        {
            clock.month++;
            clock.day = 1;
        }

        if(clock.month > 12)
        {
            clock.year++;
            clock.month = 1;
        }

        ui.RefreshTime();
    }

    private int GetLastDayOfMonth(int year, int month)
    {
        if (month == 2)
        {
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
                return 29;
            else
                return 28;
        }
        else if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            return 30;
        }
        else
        {
            return 31;
        }
    }
    
    // TALKING
    

}
