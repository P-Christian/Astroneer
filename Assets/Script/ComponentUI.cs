using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI componentText; 
    void Start()
    {
        componentText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateComponentText(PlayerInv playerInventory)
    {
        componentText.text = playerInventory.NumOfComponents.ToString();
        string dataToKeep = componentText.text;
        StaticData.valueToKeep = dataToKeep;
        if (dataToKeep == "0" )
        {
            componentText.text = "Collected Components: 0/8";
        } else
        {
            componentText.text = "Collected Components: " + dataToKeep + "/8";
        }
        
    }
}
