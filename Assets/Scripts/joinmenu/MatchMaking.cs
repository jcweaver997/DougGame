using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
using System.Collections;

public class MatchMaking : MonoBehaviour {
    NetworkManager nm;


	public void Awake(){
		nm = GetComponent<NetworkManager>();
		nm.StartMatchMaker();
	}

	public void Create(){
		
		//nm.matchMaker.CreateMatch(nm.matchName, 
		//	nm.matchSize, true, "", OnMatchCreate);
		//nm.matchMaker.CreateMatch(Global.lobbyName,(uint)Global.maxPlayers,
		//	true, "", nm.OnMatchCreate);
		Global.lobbyName = "name";
		Global.maxPlayers = 4;
		nm.matchMaker.CreateMatch(Global.lobbyName,(uint)Global.maxPlayers,
			true, "", OnMatchCreate);
	}




	public void OnMatchCreate(CreateMatchResponse response){
		if (response.success)
		{
			Debug.Log("Create match succeeded");
			nm.StartHost(new MatchInfo(response));
		}
		else
		{
			Debug.LogError("Create match failed");
			Debug.Log(response.extendedInfo);
		}
	}
}
