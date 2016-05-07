using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class nm_Button_Okay : MonoBehaviour {
    GameObject textBox;
    Text text;
    public void Start() {
        textBox = GameObject.FindGameObjectWithTag("Finish");
        text = textBox.GetComponent<Text>();
        text.text = Global.PlayerName;
    }

    public void Okay() {
        if (text.text.Length < 2)
        {
            return;
        }

        Global.PlayerName = text.text;
        SceneManager.LoadScene(1);
    }
}
