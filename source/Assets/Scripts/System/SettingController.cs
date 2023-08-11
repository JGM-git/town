using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Windows.Forms;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using Application = UnityEngine.Application;
using Screen = UnityEngine.Screen;

public class SettingController : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    private string dataPath;
    public Setting currentSetting;

    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>
    
    void Start()
    {
        dataPath = Application.persistentDataPath + "/settings.json";
        LoadData();
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
    }
}
