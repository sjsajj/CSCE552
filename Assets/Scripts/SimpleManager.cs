using System.Collections;
using UnityEngine;

public class SimpleManager : MonoBehaviour
{
    public string playerTag = "Player";
    public int mainMenuIndex = 0;
    public int winMenu = 2;
    public int loseMenu = 3;

    // Use this for initialization 
    private void Start()
    {
    }

    // Update is called once per frame 
    private void Update()
    {
    }

    private void GODied(string goTag)
    {
        if (goTag == playerTag)
        {
            Application.LoadLevel(loseMenu);
        }
    }
}