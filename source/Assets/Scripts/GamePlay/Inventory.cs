using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Localization.Plugins.XLIFF.V12;

[System.Serializable]
public class Inven : SerializableDictionary<ItemData, int> { }

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    public Inven inven;
    public int slotCount;
    public int idx;

    private UIManager ui;
    private PlayerManager playerManager;
    
    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        playerManager = FindObjectOfType<PlayerManager>();
        idx = 0;
    }

    public void GetItem(ItemData itemData, int count)
    {
        // 먼저 검색해서 있으면 그 슬롯에 개수만 더하기
        if (inven.ContainsKey(itemData))
            if (itemData.stackable)
            {
                inven[itemData] += count;
                playerManager.weight += itemData.weight * count;
                ui.RefreshInven();
                return;
            }
        
        // 남은 슬롯이 있으면 새로 추가
        if (idx < slotCount)
        {
            inven.Add(itemData, count);
            playerManager.weight += itemData.weight * count;
            idx++;
            ui.RefreshInven();
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    public void GenerateIcon(ItemData target, GameObject slot)
    {
        GetSlotIcon(slot).sprite = target.sprite;

        if (target.stackable)
        {
            if (inven[target] >= 2)
            {
                GetSlotText(slot).text = inven[target].ToString();
            }
        }
    }

    private Image GetSlotIcon(GameObject target)
    {
        Image icon = target.transform.GetChild(1).GetComponent<Image>();
        icon.enabled = true;
        return icon;
    }

    private TMP_Text GetSlotText(GameObject target)
    {
        return target.transform.GetChild(2).GetComponent<TMP_Text>();
    }
}
