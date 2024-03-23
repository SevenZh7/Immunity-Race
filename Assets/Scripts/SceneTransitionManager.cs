using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerManager : MonoBehaviour
{
    private static SceneManagerManager instance;

    private const string PreviousSceneKey = "PreviousSceneIndex";
    private int previousSceneIndex;

    private void Awake()
    {
        // Implementing the Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static SceneManagerManager Instance
    {
        get { return instance; }
    }

    public void SetPreviousSceneIndex()
    {
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt(PreviousSceneKey, previousSceneIndex);
        PlayerPrefs.Save();
        Debug.Log("Set Previous Scene Index: " + previousSceneIndex);
    }

    public void LoadPreviousScene()
    {
        int storedPreviousSceneIndex = PlayerPrefs.GetInt(PreviousSceneKey, -1);

        if (storedPreviousSceneIndex >= 0)
        {
            SceneManager.LoadScene(storedPreviousSceneIndex);
        }
        else
        {
            Debug.LogWarning("No stored previous scene available. Loading MainMenu.");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
