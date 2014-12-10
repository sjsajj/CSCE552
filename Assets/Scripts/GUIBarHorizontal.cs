using System.Collections;
using UnityEngine;

/// <summary> displays a horizontal bar with a max and min value which will appear in text on the bar </summary>
public class GUIBarHorizontal : MonoBehaviour
{
    /// <summary> the maximum value the bar can display </summary>
    public int maxValue = 110;

    /// <summary> the value displayed on the top of the fraction </summary>
    public int currentValue = 100;

    /// <summary> use this to control how much space the value read out has </summary>
    public int textSize = 50;

    /// <summary> how far the bar is from the top of the screen </summary>
    public int positionTop = 10;

    /// <summary> how far the bar is from the left of the screen </summary>
    public int positionLeft = 10;

    /// <summary> how tall the bar is, check this if the text is not fitting in the bar </summary>
    public int barHeight = 20;

    /// <summary> also controls how wide the bar is check if things are not fitting in the bar </summary>
    public float barWidth = 2;

    /// <summary> use the inspector in unity to assign this value </summary>
    /// <remarks> this is the image that will be displayed when the bar value does down </remarks>
    public Texture2D backgroundImage;

    /// <summary> use the inspector in unity to assign this value </summary>
    /// <remarks> this is the image that will be displayed as the value and will change size depending on the currentValue </remarks>
    public Texture2D foregroundImage;

    /// <summary> this will be set by the code </summary>
    private float valueBarLength;

    /// <summary> used to determine how wide the draw the bar </summary>
    private float screenSize;

    /// <summary> Use this for initialization </summary>
    private void Start()
    {
        valueBarLength = Screen.width / barWidth;
        screenSize = Screen.width / barWidth;
    }

    /// <summary> Update is called once per frame </summary>
    private void Update()
    {
        AdjustCurrentValue(0);
    }

    /// <summary> draws the bar on screen </summary>
    private void OnGUI()
    {
        // this is what controles the size of the bar in the horazontal direction 
        valueBarLength = (screenSize) * (currentValue / (float)maxValue);

        // the background 
        GUI.DrawTexture(new Rect(positionLeft, Screen.height - positionTop, screenSize, barHeight), backgroundImage);

        // the actual health bar 
        GUI.DrawTexture(new Rect(positionLeft, Screen.height - positionTop, valueBarLength, barHeight), foregroundImage);

        // the text that displays the current health over the max helth 
        GUI.Label(new Rect(positionLeft, Screen.height - positionTop, textSize, barHeight), currentValue + "/" + maxValue);
    }

    /// <summary> takes care of updating the bar </summary>
    /// <param name="adjustment"> the amount to adjust the value </param>
    private void AdjustCurrentValue(int adjustment)
    {
        currentValue += adjustment;

        // bounds checking 
        if (currentValue <= 0)
        {
            currentValue = 0;
        }

        if (currentValue >= maxValue)
        {
            currentValue = maxValue;
        }

        if (maxValue < 1)
        {
            maxValue = 1;
        }
    }
}