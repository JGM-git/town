using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    /// <summary>
    ///////////////////////////////  UI OBJECTS
    /// </summary>
    [Header ("Money")]
    public TMP_Text MoneyText;
    [Header ("Time")]
    public TMP_Text TimeText;
    public TMP_Text DateText;
    public Image WeatherIcon;
    [Header ("Menu")]
    public Button InfoButton;
    public Button ShopButton;
    public Button QuestButton;
    public Button AchieveButton;
    public Button MapButton;
    public Button SettingButton;

    /// <summary>
    /// //////////////////////////// VARIABLES
    /// </summary>
    private MainSystem mainSystem;
    
    /// <summary>
    /// //////////////////////////// VARIABLES FOR CALCULATING DATE
    /// </summary>
    private static string[] monthNames = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
    private static string[] dayNames = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
    

    /// <summary>
    /// //////////////////////////// EVENT FUNCTIONS
    /// </summary>
    
    void Start()
    {
        mainSystem = FindObjectOfType<MainSystem>();
        RefreshMoney();
        RefreshTime();
    }

    /// <summary>
    /// //////////////////////////// CUSTOM FUNCTIONS
    /// </summary>

    public void RefreshMoney()
    {
        MoneyText.text = "$" + mainSystem.money.ToString();
    }

    public void RefreshTime()
    {
        MainSystem.Clock c = mainSystem.clock;
        TimeText.text = string.Format("{0}:{1}", AddZero(c.hour), AddZero(c.minute));
        DateTime date = new DateTime(c.year, c.month, c.day);
        int dayIdx = (int) date.DayOfWeek;
        DateText.text = string.Format("{0} {1}, {2}\n{3}", monthNames[c.month - 1], c.day, c.year, dayNames[dayIdx]);
    }

    private string AddZero(int target)
    {
        if(target >= 10) return target.ToString();
        return "0" + target.ToString();
    }

    public void RefreshWeather()
    {
    }
}