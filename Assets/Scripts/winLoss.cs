using System.Collections;
using UnityEngine;

/// <summary> keeps track of the values used to determine the win and loss conditions </summary>
public class WinLoss : MonoBehaviour
{
    /// <summary> the text that will be displayed on the "found" bar </summary>
    public string foundText = "days until found ";

    /// <summary> the text that will be displayed on the "rescued" bar </summary>
    public string rescuedText = "days until rescued ";

    /// <summary> use this to control how much space the value read out has </summary>
    public int textSize = 250;

    /// <summary> how far the rescued bar is from the top of the screen </summary>
    public int positionTopRescued = 10;

    /// <summary> how far the found bar is from the top of the screen </summary>
    public int positionTopFound = 10;

    /// <summary> how far the rescued bar is from the left of the screen </summary>
    public int positionLeftRescued = 140;

    /// <summary> how far the found bar is from the left of the screen </summary>
    public int positionLeftFound = 10;

    /// <summary> how tall the bar is, check this if the text is not fitting in the bar </summary>
    public int barHeight = 20;

    /// <summary> the days remaining until the player is found by the bad guys and loses </summary>
    private int daysUntilFound = 10;

    /// <summary> the days remaining until the player wins the game </summary>
    private int daysUntilRescued = 10;

    /// <summary> Gets or sets how many days until the player loses </summary>
    /// <value> the amount of days until the player loses </value>
    public int DaysUntilFound
    {
        get
        {
            return this.daysUntilFound;
        }

        set
        {
            if (value < 0)
            {
                this.daysUntilFound = 0;
            }
            else
            {
                this.daysUntilFound = value;
            }
        }
    }

    /// <summary> Gets or sets how many days until the player wins </summary>
    /// <value> the days remaining until the player wins the game </value>
    public int DaysUntilRescued
    {
        get
        {
            return this.daysUntilRescued;
        }

        set
        {
            if (value < 0)
            {
                this.daysUntilRescued = 0;
            }
            else
            {
                this.daysUntilRescued = value;
            }
        }
    }

    /// <summary> rendering the text on screen </summary>
    private void OnGUI()
    {
        // the text that displays the current health over the max helth 
        GUI.Label(new Rect(this.positionLeftFound, this.positionTopFound, this.textSize, this.barHeight), this.foundText + this.daysUntilFound);
        GUI.Label(new Rect(Screen.width - this.positionLeftRescued, this.positionTopRescued, this.textSize, this.barHeight), this.rescuedText + this.daysUntilRescued);
    }
}