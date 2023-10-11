using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComponentScript : MonoBehaviour
{
    public GameObject myObject;
    public string interactText = "Press E to interact";
    private Transform playerTransform; // Reference to the player's transform
    private bool inRange = false;
    private bool collected;
    [SerializeField] private string id;

    private PlayerInv playerInventory; // Reference to the PlayerInv script

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
        LoadState();
        playerInventory = GetComponent<PlayerInv>(); // Assuming PlayerInv is attached to the same GameObject
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInv otherPlayerInventory = other.GetComponent<PlayerInv>();
        if (otherPlayerInventory != null && !collected)
        {
            collected = true;
            gameObject.SetActive(false);
            otherPlayerInventory.ComponentsCollected();
            SaveState();
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
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
        }
    }

    private void SaveState()
    {
        PlayerPrefs.SetInt(id, 10);
        PlayerPrefs.Save();
    }

    private void LoadState()
    {
        if (PlayerPrefs.HasKey(id))
        {
            collected = true;

            // Check if the component should be enabled or disabled based on its collected state
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        // Save the state when a scene is unloaded
        SaveState();
    }

    private void OnEnable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnApplicationQuit()
    {
        // Reset the state when the application is quitting
        ResetState();
    }

    public void ResetState()
    {
        collected = false;

        // Enable the component when resetting the state
        gameObject.SetActive(true);

        PlayerPrefs.DeleteKey(id);
    }
}
