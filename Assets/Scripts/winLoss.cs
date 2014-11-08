﻿using UnityEngine;
using System.Collections;

public class winLoss : MonoBehaviour
{
    //values to display
    public string foundText = "days until found ";
    public string rescuedText = "days until rescued ";
    private int daysUntilFound = 10;
    private int daysUntilRescued = 10;

    //this is a C# propertie which means it has assessor and mutators built in so you dont need to explicitly call them
    public int DaysUntilFound
    {
        get { return daysUntilFound; }
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

    //this is a C# propertie which means it has assessor and mutators built in so you dont need to explicitly call them
    public int DaysUntilRescued
    {
        get { return daysUntilRescued; }
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

    //rendering the text on screen
    void OnGUI()
    {
        //the text that displays the current health over the max helth
        GUI.Label(new Rect(positionLeftFound, positionTopFound, textSize, barHeight), foundText + daysUntilFound);
        GUI.Label(new Rect(Screen.width - positionLeftRescued, positionTopRescued, textSize, barHeight), rescuedText + daysUntilRescued);
    }
}
