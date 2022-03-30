using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    public static SceneManaging instance;

    public int currSceneIndex = 0;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(this);
    }
    public void NextScene()
    {
        int ndx = currSceneIndex++ % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(ndx);
    }

    public void PreviousScene()
    {
        if(currSceneIndex == 0)
        {
            currSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        }
        else
        {
            currSceneIndex -= 1;
        }
        SceneManager.LoadScene(currSceneIndex-- % SceneManager.sceneCountInBuildSettings);
    }
}
