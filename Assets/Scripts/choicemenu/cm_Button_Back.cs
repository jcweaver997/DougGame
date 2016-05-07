using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class cm_Button_Back : MonoBehaviour {
    public void Back()
    {
        SceneManager.LoadScene(0); // 0 is title screen

    }
}
