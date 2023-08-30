using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [Header ("Menu Buttons")]
    public Button InfoButton;
    public Button ShopButton;
    public Button QuestButton;
    public Button AchieveButton;
    public Button MapButton;
    public Button SettingButton;
    [Header("Popup Windows")]
    public GameObject InfoPanel;
    public GameObject QuestPanel;
    public GameObject AchievePanel;
    public GameObject InvenPanel;
    public GameObject SettingPanel;
    public GameObject EquipPanel;
    [Header("Info Objects")]
    public TMP_Text KnowledgeText;
    public TMP_Text LuckText;
    public TMP_Text StrengthText;
    public TMP_Text DrivingText;
    public TMP_Text ReputationText;
    public TMP_Text FaithText;
    public TMP_Text LifeText;
    [Header("ETC")]
    public Slider StaminaSlider;

    public Image StaminaImage;
    public GameObject QuitPanel;

    /// <summary>
    /// VARIABLES
    /// </summary>
    private MainSystem mainSystem;
    private PlayerManager playerManager;

    public bool infoOpened = false;
    public bool invenOpened = false;
    public bool questOpened = false;
    public bool achieveOpened = false;
    public bool mapOpened = false;
    public bool settingOpened = false;
    public bool quitOpened = false;
    public bool equipOpened = false;

    public Color CanRun;
    public Color CannotRun;
    
    public Stack<Action> windowStack = new Stack<Action>();
    
    /// <summary>
    /// VARIABLES FOR CALCULATING DATE
    /// </summary>
    private static string[] monthNames = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
    private static string[] dayNames = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
    

    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>
    
    void Start()
    {
        mainSystem = FindObjectOfType<MainSystem>();
        playerManager = FindObjectOfType<PlayerManager>();
        RefreshMoney();
        RefreshTime();
    }

    void Update()
    {
        StaminaBar();
    }

    /// <summary>
    /// CUSTOM FUNCTIONS
    /// </summary>

    private void StaminaBar()
    {
        StaminaSlider.value = Mathf.Lerp(StaminaSlider.value, playerManager.stamina / playerManager.maxStamina, Time.deltaTime);
        if (playerManager.stamina / playerManager.maxStamina * 100f > 10f) StaminaImage.color = CanRun;
        else StaminaImage.color = CannotRun;
    }
    
    public void RefreshMoney()
    {
        MoneyText.text = "$" + playerManager.money.ToString();
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

    /// <summary>
    /// BUTTON ONCLICK
    /// </summary>

    public void ManageInfo()
    {
        infoOpened = !infoOpened;
        if(infoOpened)
        {
            RefreshInfo();
            PanelOpenAnim(InfoPanel);
            windowStack.Push(ManageInfo);
        }
        else
        {
            PanelCloseAnim(InfoPanel);
            if(windowStack.Peek() == ManageInfo) windowStack.Pop();
            else ClearStack(ManageInfo);
        }
    }
    
    public void ManageQuest()
    {
        questOpened = !questOpened;
        if(questOpened)
        {
            PanelOpenAnim(QuestPanel);
            windowStack.Push(ManageQuest);
        }
        else
        {
            PanelCloseAnim(QuestPanel);
            if(windowStack.Peek() == ManageQuest) windowStack.Pop();
            else ClearStack(ManageQuest);
        }
    }

    public void ManageAchieve()
    {
        achieveOpened = !achieveOpened;
        if(achieveOpened)
        {
            PanelOpenAnim(AchievePanel);
            windowStack.Push(ManageAchieve);
        }
        else
        {
            PanelCloseAnim(AchievePanel);
            if(windowStack.Peek() == ManageAchieve) windowStack.Pop();
            else ClearStack(ManageAchieve);
        }
    }

    public void ManageInven()
    {
        invenOpened = !invenOpened;
        if(invenOpened)
        {
            PanelOpenAnim(InvenPanel);
            windowStack.Push(ManageInven);
        }
        else
        {
            PanelCloseAnim(InvenPanel);
            if(windowStack.Peek() == ManageInven) windowStack.Pop();
            else ClearStack(ManageInven);
        }
    }
    
    public void ManageSetting()
    {
        settingOpened = !settingOpened;
        if(settingOpened)
        {
            PanelOpenAnim(SettingPanel);
            windowStack.Push(ManageSetting);
        }
        else
        {
            PanelCloseAnim(SettingPanel);
            if(windowStack.Peek() == ManageSetting) windowStack.Pop();
            else ClearStack(ManageSetting);
        }
    }

    public void ManageEquip()
    {
        equipOpened = !equipOpened;
        if(equipOpened)
        {
            PanelOpenAnim(EquipPanel);
            windowStack.Push(ManageEquip);
        }
        else
        {
            PanelCloseAnim(EquipPanel);
            if(windowStack.Peek() == ManageEquip) windowStack.Pop();
            else ClearStack(ManageEquip);
        }
        
    }

    private void PanelOpenAnim(GameObject target)
    {
        target.SetActive(true);
        target.transform.localScale = Vector3.one * 0.1f;
        var seq = DOTween.Sequence();
        seq.Append(target.transform.DOScale(1.05f, 0.2f));
        seq.Append(target.transform.DOScale(1f, 0.1f));
        seq.Play();
        target.transform.SetAsLastSibling();
    }

    private void PanelCloseAnim(GameObject target)
    {
        var seq = DOTween.Sequence();
        seq.Append(target.transform.DOScale(1.05f, 0.1f));
        seq.Append(target.transform.DOScale(0.1f, 0.1f));
        seq.Play().OnComplete(() =>
        {
            target.SetActive(false);
        });
    }
    
    private void ClearStack(Action target)
    {
        Stack<Action> tempStack = new Stack<Action>();
        while (windowStack.Count > 0)
        {
            Action method = windowStack.Pop();
            if (method != target)
            {
                tempStack.Push(method);
            }
        }
        while (tempStack.Count > 0)
        {
            windowStack.Push(tempStack.Pop());
        }
    }

    /// <summary>
    /// QUIT
    /// </summary>
    
    public void ManageQuit()
    {
        quitOpened = !quitOpened;
        QuitPanel.SetActive(quitOpened);
    }

    public void QuitGame()
    {
        // 추후 타이틀 씬으로 돌아가도록 변경하기
        Application.Quit();
    }

    /// <summary>
    /// WEATHER
    /// </summary>
    
    public void ChangeWeatherIcon(Sprite targetIcon)
    {
        WeatherIcon.sprite = targetIcon;
    }

    private void RefreshInfo()
    {
        KnowledgeText.text = playerManager.knowledge.ToString();
        LuckText.text = playerManager.luck.ToString();
        StrengthText.text = playerManager.strength.ToString();
        DrivingText.text = playerManager.driving.ToString();
        ReputationText.text = playerManager.reputation.ToString();
        FaithText.text = playerManager.faith.ToString();
        LifeText.text = playerManager.life.ToString();
    }
}