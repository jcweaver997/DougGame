using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class tt_Button_Play : MonoBehaviour {
    private AsyncOperation nextSceneLoaded;

    public void Start()
    {
        nextSceneLoaded = SceneManager.LoadSceneAsync(1); // 1 is namemenu
        nextSceneLoaded.allowSceneActivation = false;
    }

public void Play()
    {
        nextSceneLoaded.allowSceneActivation = true;

    }
}
