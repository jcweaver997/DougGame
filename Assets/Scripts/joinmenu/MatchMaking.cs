using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MatchMaking : MonoBehaviour {
    NetworkManager nm;

    public void Start()
    {
        nm = GetComponent<NetworkManager>();
        nm.StartMatchMaker();
        
    }
}
