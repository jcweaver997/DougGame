using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class jm_Button_Back : MonoBehaviour {
    public void Back()
    {
        SceneManager.LoadScene(1); // 1 is choice menu

    }
}
