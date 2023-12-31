using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Michsky.MUIP;
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
    [Header("Achievements")]
    public GameObject scrollContent;
    public GameObject achievePrefab;
    public CustomDropdown achieveFilter;
    public Scrollbar achieveScroll;
    [Header("Inventory")]
    public Transform invenContent;
    public RectTransform backgroundRect;
    public RectTransform slotRect;
    public GameObject slotPrefab;
    public TMP_Text weightText;
    public GameObject WarningIcon;
    public int slotPerLine = 7;
    public GameObject[] slotArr;
    [Header("Dialog")]
    public GameObject Dialog;
    public TMP_Text DialogText;
    public GameObject NextButton;
    public GameObject AcceptButton;
    public GameObject RejectButton;
    [Header("Quest")]
    public TMP_Text questCountText;
    public Transform questContent;
    public GameObject questPrefab;
    public TMP_Text questTitleText;
    public TMP_Text questDescriptionText;
    public TMP_Text questRewardText;
    [Header("ETC")]
    public Slider StaminaSlider;
    public GameObject CarSpeedText;

    public Image StaminaImage;
    public GameObject QuitPanel;

    /// <summary>
    /// VARIABLES
    /// </summary>
    private GameManager gameManager;
    private PlayerManager playerManager;
    private QuestManager questManager;
    private Inventory inven;

    public bool infoOpened = false;
    public bool invenOpened = false;
    public bool questOpened = false;
    public bool achieveOpened = false;
    public bool mapOpened = false;
    public bool settingOpened = false;
    public bool quitOpened = false;
    public bool equipOpened = false;
    public bool speedOpened = false;
    public bool dialogOpened = false;

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
        gameManager = FindObjectOfType<GameManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        questManager = FindObjectOfType<QuestManager>();
        inven = FindObjectOfType<Inventory>();
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

    public void ManageSpeedText()
    {
        speedOpened = !settingOpened;
        CarSpeedText.SetActive(speedOpened);
    }
    
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
        GameManager.Clock c = gameManager.clock;
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
            RefreshQuest();
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
            RefreshAchieve("All");
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
            RefreshInven();
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

    /// <summary>
    /// QUEST
    /// </summary>
    
    public void RefreshQuest()
    {
        questCountText.text = string.Format("{0} quests in progress", questManager.questList.Count);
     
        foreach (Transform child in questContent.transform)
            Destroy(child.gameObject);
        
        foreach (Quest quest in questManager.questList)
        {
            GameObject questItem = Instantiate(questPrefab, questContent);
            questItem.transform.SetParent(questContent);
            questItem.GetComponent<Button>().onClick.AddListener(() =>
                FindObjectOfType<QuestPanel>().ManagePanel(quest)
                );
            GetQuestTitleText(questItem).text = quest.questName;
        }
    }

    public void SetPanelDetail(Quest quest)
    {
        questTitleText.text = quest.questName;
        questDescriptionText.text = quest.description;
        // questRewardText.text = 
    }

    private TMP_Text GetQuestTitleText(GameObject target)
    {
        return target.transform.GetChild(0).GetComponent<TMP_Text>();
    }

    /// <summary>
    /// DIALOG
    /// </summary>

    public void ManageDialog()
    {
        dialogOpened = !dialogOpened;
        Dialog.SetActive(dialogOpened);
    }
    
    public void PrintDialog(string target)
    {
        DialogText.DOText(target, 1f);
    }

    public void LastDialog()
    {
        NextButton.SetActive(false);
        AcceptButton.SetActive(true);
        RejectButton.SetActive(true);
    }

    public void ResetDialog()
    {
        NextButton.SetActive(true);
        AcceptButton.SetActive(false);
        RejectButton.SetActive(false);
        DialogText.text = "";
    }

    public void AcceptQuest()
    {
        questManager.AddQuest();
        ResetDialog();
        ManageDialog();
    }

    public void RejectQuest()
    {
        ResetDialog();
        ManageDialog();
    }
    
    /// <summary>
    /// Achievements
    /// </summary>

    public void RefreshAchieve(string Filter)
    {
        foreach (Transform child in scrollContent.transform)
            Destroy(child.gameObject);
        AchievementManager achievementManager = AchievementManager.instance;
        int count = achievementManager.GetAllCount();
        for (int i = 0; i < count; i++)
        {
            if((Filter.Equals("All")) || (Filter.Equals("Achieved") && achievementManager.States[i].Achieved) || (Filter.Equals("Unachieved") && !achievementManager.States[i].Achieved))
            {
                AddAchievementToUI(achievementManager.AchievementList[i], achievementManager.States[i]);
            }
        }

        achieveScroll.value = 1;
    }
    
    public void AddAchievementToUI(AchievementInfromation Achievement, AchievementState State)
    {
        UIAchievement UIAchievement = Instantiate(achievePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity).GetComponent<UIAchievement>();
        UIAchievement.Set(Achievement, State);
        UIAchievement.transform.SetParent(scrollContent.transform);
    }
    
    public void ChangeFilter()
    {
        RefreshAchieve(achieveFilter.selectedText.text);
    }
    
    /// <summary>
    /// INVENTORY
    /// </summary>
    public void RefreshInven()
    {
        foreach (Transform child in invenContent)
            Destroy(child.gameObject);
        
        ResizeInven();
        slotArr = new GameObject[inven.slotCount];

        List<ItemData> invenKeys = new List<ItemData>(inven.inven.Keys);
        for (int i = 0; i < inven.slotCount; i++)
        {
            slotArr[i] = Instantiate(slotPrefab, invenContent);
            slotArr[i].transform.SetParent(invenContent);
            
            if(i < invenKeys.Count)
                inven.GenerateIcon(invenKeys[i], slotArr[i]);
        }

        float weightPercent = playerManager.GetWeightPercent();
        WarningIcon.SetActive(weightPercent > 90f);
        weightText.text = string.Format("Weight {0}%", Math.Round(weightPercent, 2));
    }

    public void ResizeInven()
    {
        int verticalSize = DivideSlotCount(inven.slotCount) * 70 + 20;
        slotRect.sizeDelta = new Vector2(510, verticalSize);
        slotRect.anchoredPosition =
            new Vector2(slotRect.anchoredPosition.x, 130f + (DivideSlotCount(inven.slotCount) - 3) * 35f);
        backgroundRect.sizeDelta = new Vector2(540, verticalSize + 150);
    }

    private int DivideSlotCount(int target)
    {
        return (target % 7 == 0) ? target / 7 : target / 7 + 1;
    }
}