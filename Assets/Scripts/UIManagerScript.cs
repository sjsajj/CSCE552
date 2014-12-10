using UnityEngine;
using System.Collections;

public class UIManagerScript : MonoBehaviour {

	public void StartGame(int level)
	{
		Application.LoadLevel(level);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
