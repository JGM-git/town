using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemData[] inven;
    public int slotCount;
    public int count;
    void Start()
    {
        inven = new ItemData[slotCount];
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetItem(ItemData itemData)
    {
        if (count < inven.Length) 
        {
            inven[count] = itemData;
            count++;
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }
}
