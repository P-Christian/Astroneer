using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    bool gameHasEnded = false;
    public float restartDelay = 1;
    private PlayerInv playerInventory;
    [SerializeField] GameObject inventory;

    private void Awake()
    {
        playerInventory = inventory.GetComponent<PlayerInv>();
    }
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            StaticData.valueToKeep = "0";
            PlayerPrefs.DeleteAll();
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Deads");
    }
}
