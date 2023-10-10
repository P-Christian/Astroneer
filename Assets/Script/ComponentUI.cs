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
        StaticData.valueToKeep = Convert.ToInt32(dataToKeep);
    }
}
