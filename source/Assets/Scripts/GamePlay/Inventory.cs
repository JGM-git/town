using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
