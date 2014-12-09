using System.Collections;
using UnityEngine;

// displays a horizontal bar with a max and min value which will appear in text on the bar 
public class hydrationBar : MonoBehaviour
{
    // values for the bar
    private int maxHydration = 100;
    private int currentHydration = 100;

    /// <summary> Gets or sets the maximum value displayed on the bar </summary>
    public int MaxHydration
    {
        get
        {
            return maxHydration;
        }

        set
        {
            if (value > 0)
            {
                maxHydration = value;
            }
            else
            {
                maxHydration = 1;
            }
        }
    }

    /// <summary> Gets or sets the current value displayed on the bar </summary>
    public int CurrentHydration
    {
        get
        {
            return currentHydration;
        }

        set
        {
            if (value < 0)
            {
                currentHydration = 0;
            }
            else if (value >= maxHydration)
            {
                currentHydration = maxHydration;
            }
            else
            {
                currentHydration = value;
            }
        }
    }

    // use this to control how much space the value read out has
    public int textSize = 50;

    // positioning the bar
    public int positionTop = 90;
    public int positionLeft = 10;
    public int barHeight = 20;
    public float barWidth = 2;

    // this will be set by the code
    private float valueBarLength;

    private float screenSize;

    // texturing the bar
    public Texture2D backgroundImage;
    public Texture2D foregroundImage;

    // Use this for initialization 
    private void Start()
    {
        valueBarLength = Screen.width / barWidth;
        screenSize = Screen.width / barWidth;
    }

    /// <summary> draws the bar on screen </summary>
    private void OnGUI()
    {
        // this is what controles the size of the bar in the horazontal direction
        valueBarLength = (screenSize) * (currentHydration / (float)maxHydration);

        // the background
        GUI.DrawTexture(new Rect(positionLeft, Screen.height - positionTop, screenSize, barHeight), backgroundImage);

        // the actual health bar
        GUI.DrawTexture(new Rect(positionLeft, Screen.height - positionTop, valueBarLength, barHeight), foregroundImage);

        // the text that displays the current health over the max helth
        GUI.Label(new Rect(positionLeft, Screen.height - positionTop, textSize, barHeight), ((float)currentHydration / (float)maxHydration) * 100 + "%");
    }
}