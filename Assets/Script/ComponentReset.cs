using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentReset : MonoBehaviour
{
    ComponentScript componentScript;
    [SerializeField] GameObject components;
    // Start is called before the first frame update
    private void Awake()
    {
        componentScript = components.GetComponentInChildren<ComponentScript>(true);

        if (componentScript == null)
        {
            Debug.LogError("ComponentScript not found on components GameObject or its children.");
        }
        componentScript.ResetState();
    }
    // Update is called once per frame
    void Update()
    {
        componentScript.LoadState();
    }
}
