using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class tt_Button_Play : MonoBehaviour {
    private AsyncOperation nextSceneLoaded;

    public void Start()
    {
        nextSceneLoaded = SceneManager.LoadSceneAsync(3); // 3 is namemenu
        nextSceneLoaded.allowSceneActivation = false;
    }

public void Play()
    {
        nextSceneLoaded.allowSceneActivation = true;

    }
}
