using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Windows.Forms;
using Application = UnityEngine.Application;
using Screen = UnityEngine.Screen;

/// <summary>
/// 유니티 UI 드롭다운을 Modern UI Pack 드롭다운으로 교체해야 함
/// </summary>

public class SettingController : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    private string dataPath;
    public Setting currentSetting;
    private Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>
    
    void Start()
    {
        dataPath = Application.persistentDataPath + "/settings.json";
        LoadData();
    }
    
    /// <summary>
    /// RESOLUTION
    /// </summary>

    public void InitResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + " x " + resolution.height;
            resolutionDropdown.options.Add(new Dropdown.OptionData(option));
        }
        int currentResolutionIndex = GetCurrentResolutionIndex();
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    
    private int GetCurrentResolutionIndex()
    {
        Resolution currentResolution = Screen.currentResolution;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
            {
                return i;
            }
        }
        return -1;
    }
    
    /// <summary>
    /// LOAD / SAVE FUNCTIONS
    /// </summary>

    public void SaveData(Setting target)
    {
        string jsonData = JsonUtility.ToJson(target);
        File.WriteAllText(dataPath, jsonData);
    }
    
    public void LoadData()
    {
        // settings.json 파일이 존재하면 읽어 오기
        if(File.Exists(dataPath))
        {
            try
            {
                string jsonData = File.ReadAllText(dataPath);
                currentSetting = JsonUtility.FromJson<Setting>(jsonData);
            }
            catch
            {
                string message = "Your option file is broken. It'll be reseted. Please run again.";
                string caption = "Fatal Error!";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                DialogResult result = MessageBox.Show(message, caption, button, icon);
                if (result == DialogResult.OK)
                {
                    File.Delete(dataPath);
                    Application.Quit();
                }
            }
        }
        // 존재하지 않으면 기본값의 설정 파일 생성
        else
        {
            currentSetting = new Setting();
            SaveData(currentSetting);
        }
        
        ApplySetting();
        InitSettingPanel();
    }

    public void ApplySetting()
    {
        // GENERAL
        string[] resolutionData = currentSetting.general.resolution.Split("*");
        FullScreenMode screenMode;
        if (currentSetting.general.screen == "FullScreen") screenMode = FullScreenMode.FullScreenWindow;
        else if (currentSetting.general.screen == "Windowed") screenMode = FullScreenMode.Windowed;
        else screenMode = FullScreenMode.MaximizedWindow;
        Screen.SetResolution(int.Parse(resolutionData[0]), int.Parse(resolutionData[1]), screenMode);
    }

    private void InitSettingPanel()
    {
        InitResolution();
    }
}
