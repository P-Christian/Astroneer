using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComponentScript : MonoBehaviour
{
    public GameObject myObject;
    public string interactText = "Press E to interact";
    private Transform playerTransform; // Reference to the player's transform
    private bool inRange = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInv playerInventory = other.GetComponent<PlayerInv>();
        if (playerInventory != null )
        {
            playerInventory.ComponentsCollected();
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
    void Update()
    {
        PlayerInv playerInventory = GetComponent<PlayerInv>();

        if (playerInventory != null)
        {
        if (inRange && Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
            }
                
        }
    }
}
