using System.Collections;
using UnityEngine;

public class winLoss : MonoBehaviour
{
    // values to display 
    public string foundText = "days until found ";
    public string rescuedText = "days until rescued ";
    private int daysUntilFound = 10;
    private int daysUntilRescued = 10;

    /// <summary> Gets or sets how many days until the player loses </summary>
    public int DaysUntilFound
    {
        get
        {
            return daysUntilFound;
        }
        set
        {
            if (value < 0)
            {
                daysUntilFound = 0;
            }
            else
            {
                daysUntilFound = value;
            }
        }
    }

    /// <summary> Gets or sets how many days until the player wins </summary>
    public int DaysUntilRescued
    {
        get
        {
            return daysUntilRescued;
        }
        set
        {
            if (value < 0)
            {
                daysUntilRescued = 0;
            }
            else
            {
                daysUntilRescued = value;
            }
        }
    }

    // use this to control how much space the value read out has 
    public int textSize = 250;

    // positioning the bar 
    public int positionTopRescued = 10;

    public int positionTopFound = 10;
    public int positionLeftRescued = 140;
    public int positionLeftFound = 10;
    public int barHeight = 20;

    // rendering the text on screen 
    private void OnGUI()
    {
        // the text that displays the current health over the max helth 
        GUI.Label(new Rect(positionLeftFound, positionTopFound, textSize, barHeight), foundText + daysUntilFound);
        GUI.Label(new Rect(Screen.width - positionLeftRescued, positionTopRescued, textSize, barHeight), rescuedText + daysUntilRescued);
    }
}