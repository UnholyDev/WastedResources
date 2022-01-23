using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public int currentScene;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(this);
    }

    public void GoNext()
    {
        currentScene++;

        if (currentScene > 2)
            currentScene = 0;

        SceneManager.LoadScene(currentScene);
    }
}
