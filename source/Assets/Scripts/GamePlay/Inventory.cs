using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Localization.Plugins.XLIFF.V12;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// VARIABLES
    /// </summary>
    public ItemData[] inven;
    public int slotCount;
    public int idx;

    private UIManager ui;
    
    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>
    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        inven = new ItemData[slotCount];
        idx = 0;
    }

    public void GetItem(ItemData itemData)
    {
        // 먼저 검색해서 있으면 그 슬롯에 개수만 더하기
        int targetIdx = SearchItem(itemData);
        if (targetIdx > -1 && inven[targetIdx].stackable)
        {
            inven[targetIdx].quantity += itemData.quantity;
            ui.RefreshInven();
            return;
        }
        
        // 남은 슬롯이 있으면 새로 추가
        if (idx < inven.Length)
        {
            inven[idx] = itemData;
            idx++;
            ui.RefreshInven();
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    public int SearchItem(ItemData target)
    {
        for (int i = 0; i < idx; i++)
            if (inven[i].itemName == target.itemName) return i;
        
        return -1;
    }

    public void GenerateIcon(ItemData target, GameObject slot)
    {
        GetSlotIcon(slot).sprite = target.sprite;

        if (target.stackable)
        {
            if (target.quantity >= 2)
            {
                GetSlotText(slot).text = target.quantity.ToString();
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
