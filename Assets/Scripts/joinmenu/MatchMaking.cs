using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
using System.Collections;
using System.Collections.Generic;

public class MatchMaking : MonoBehaviour {
    NetworkManager nm;
	public List<jm_MatchList_Item> positons;
	public GameObject next, previous;
	public List<MatchDesc> matches;
	public Text pageNumber;

	private int ppageNum = 0;
	public int pageNum{
		get{return ppageNum;}
		set{ppageNum = value;
			UpdatePageNumber();}
	}



	public void Awake(){
		nm = NetworkManager.singleton;
		nm.StartMatchMaker();


		if(positons==null){
			Debug.LogError("MatchList items not setup");
		}else if(positons.Count==0){
			Debug.LogError("MatchList items not setup");
		}

		next.GetComponent<Button>().onClick.RemoveAllListeners();
		next.GetComponent<Button>().onClick.AddListener(Next);
		previous.GetComponent<Button>().onClick.RemoveAllListeners();
		previous.GetComponent<Button>().onClick.AddListener(Previous);

		matches = new List<MatchDesc>();
		pageNum = 0;
		UpdateList();

	}

	public void ListMatchCallback(ListMatchResponse res){
		if(nm==null)return;
		matches = res.matches;
		UpdateList();
	}

	public void Next(){
		pageNum++;
	}

	public void Previous(){
		pageNum = Mathf.Max(0,pageNum-1);
	}

	public void Create(){
		Global.lobbyName = "name";
		Global.maxPlayers = 4;
		nm.matchMaker.CreateMatch(Global.lobbyName,(uint)Global.maxPlayers,
			true, "", OnMatchCreate);
	}

	public void UpdateList(){
		if(positons[0]==null)return;

		int numberShown = matches.Count-pageNum*positons.Count;
		if(numberShown<=0 && matches.Count > 0){
			pageNum--;
			UpdateList();
			return;
		}

		nm.matchMaker.ListMatches(0,20,"",ListMatchCallback);

		numberShown = Mathf.Min(numberShown, positons.Count);

		for(int i = 0; i < numberShown; i++){
			positons[i].panel.SetActive(true);
			positons[i].name.text = matches[i+pageNum*positons.Count].name;
			positons[i].number.text = matches[i+pageNum*positons.Count].currentSize+"/"+matches[i+pageNum*positons.Count].maxSize;
		}
		for (int i = 4; i >= numberShown; i--){
			positons[i].panel.SetActive(false);
		}

	}

	public void UpdatePageNumber(){
		int numberPages = Mathf.Max(1, matches.Count/positons.Count);

		pageNumber.text = (pageNum+1)+"/"+numberPages;
		UpdateList();

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
