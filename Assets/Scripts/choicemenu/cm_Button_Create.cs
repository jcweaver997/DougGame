using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class cm_Button_Create : MonoBehaviour {
    public void Create()
    {
        SceneManager.LoadScene(3); // 3 is createmenu
    }
}
