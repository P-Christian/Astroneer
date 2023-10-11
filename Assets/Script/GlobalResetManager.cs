using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalResetManager : MonoBehaviour
{
    private static bool isQuitting = false;
    private static int instanceCount = 0;

    void OnEnable()
    {
        instanceCount++;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnDisable()
    {
        instanceCount--;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    void Awake()
    {
        // Make the GameObject persistent across scenes
        DontDestroyOnLoad(gameObject);
    }

    void OnSceneUnloaded(Scene scene)
    {
        // Check if this is the last scene
        if (SceneManager.sceneCount == 0 && isQuitting)
        {
            // The application is quitting, call your global reset logic here
            ResetAllStates();
        }
    }

    void OnApplicationQuit()
    {
        // The application is about to quit, set the flag
        isQuitting = true;

        // Call your global reset logic here (for the current scene)
        ResetAllStates();
    }

    public static void ResetAllStates()
    {
        // Iterate through all scenes and reset their states
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            GameObject[] rootObjects = scene.GetRootGameObjects();

            foreach (GameObject rootObject in rootObjects)
            {
                ComponentScript component = rootObject.GetComponent<ComponentScript>();
                if (component != null)
                {
                    component.ResetState();
                }
            }
        }
    }

    public static int GetInstanceCount()
    {
        return instanceCount;
    }
    
}