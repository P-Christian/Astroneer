using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiveValue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI componentText;

    public void Start()
    {
        int newText = StaticData.valueToKeep;
        componentText.text = Convert.ToString(newText);
    }
}
