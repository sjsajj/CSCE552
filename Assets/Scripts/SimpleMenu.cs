using UnityEngine;
using System.Collections;

public class SimpleMenu : MonoBehaviour {

	public Texture2D bgImage;
	public string buttonName = "Start Game";
	public Vector2 buttonDim = new Vector2(100,100);
	public int nextScene = 1;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), bgImage);
		if(GUI.Button(new Rect(Screen.width/2 - buttonDim.x/2, Screen.height/2 - buttonDim.y/2, buttonDim.x, buttonDim.y), buttonName))
		{
			Application.LoadLevel(nextScene);
		}
	}
}
