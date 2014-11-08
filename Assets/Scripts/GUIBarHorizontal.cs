using UnityEngine;
using System.Collections;

//displays a horizontal bar with a max and min value which will appear in text on the bar
public class GUIBarHorizontal : MonoBehaviour
{
    //values for the bar
    public int maxValue = 110;
    public int currentValue = 100;

    //use this to control how much space the value read out has
    public int textSize = 50;

    //positioning the bar
    public int positionTop = 10;
    public int positionLeft = 10;
    public int barHeight = 20;
    public float barWidth = 2;

    //this will be set by the code
    private float valueBarLength;
    private float screenSize;

    //texturing the bar
    public Texture2D backgroundImage;
    public Texture2D foregroundImage;

    // Use this for initialization
    void Start()
    {
        valueBarLength = Screen.width / barWidth;
        screenSize = Screen.width / barWidth;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCurrentValue(0);
    }

    //draws the bar on screen
    void OnGUI()
    {
        //this is what controles the size of the bar in the horazontal direction
        valueBarLength = (screenSize) * (currentValue / (float)maxValue);

        //the background
        GUI.DrawTexture(new Rect(positionLeft, Screen.height - positionTop, screenSize, barHeight), backgroundImage);

        //the actual health bar
        GUI.DrawTexture(new Rect(positionLeft, Screen.height - positionTop, valueBarLength, barHeight), foregroundImage);

        //the text that displays the current health over the max helth
        GUI.Label(new Rect(positionLeft, Screen.height - positionTop, textSize, barHeight), currentValue + "/" + maxValue);
    }

    //takes care of updating the bar
    private void AdjustCurrentValue(int adjustment)
    {
        currentValue += adjustment;

        //bounds checking
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
