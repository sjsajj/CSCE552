using UnityEngine;
using System.Collections;

public class SimpleManager : MonoBehaviour {

	public string playerTag = "Player";
	public int mainMenuIndex = 0;
	public int winMenu = 2;
	public int loseMenu = 3;
	

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void GODied(string goTag)
	{
		if(goTag == playerTag)
		{
			Application.LoadLevel (loseMenu);
		}
	}
}
