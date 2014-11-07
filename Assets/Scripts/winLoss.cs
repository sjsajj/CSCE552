using UnityEngine;
using System.Collections;

public class winLoss : MonoBehaviour
{
    //values for the bar
    private int daysUntilFound = 10;
    private int daysUntilRescued = 10;

    //use this to control how much space the value read out has
    public int textSize = 250;

    //positioning the bar
    public int positionTopRescued = 10;
    public int positionTopFound = 10;
    public int positionLeftRescued = 140;
    public int positionLeftFound = 10;
    public int barHeight = 20;

    //this will be set by the code
    private float valueBarLength;
    private float screenSize;

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        //the text that displays the current health over the max helth
        GUI.Label(new Rect(positionLeftFound, positionTopFound, textSize, barHeight), "days until found " + daysUntilFound);
        GUI.Label(new Rect(Screen.width - positionLeftRescued, positionTopRescued, textSize, barHeight), "days until rescued " + daysUntilRescued);
    }
}
