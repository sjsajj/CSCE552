using UnityEngine;
using System.Collections;

//displays a horizontal bar with a max and min value which will appear in text on the bar
public class hydrationBar : MonoBehaviour
{
    //values for the bar
    private int maxHydration = 100;
    private int currentHydration = 100;

    //use this to control how much space the value read out has
    public int textSize = 50;

    //positioning the bar
    public int positionTop = 90;
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
        AdjustCurrentValue();
    }

    /// <summary>
    /// draws the bar on screen
    /// </summary>
    void OnGUI()
    {
        //the background
        GUI.DrawTexture(new Rect(positionLeft, Screen.height - positionTop, screenSize, barHeight), backgroundImage);

        //the actual health bar
        GUI.DrawTexture(new Rect(positionLeft, Screen.height - positionTop, valueBarLength, barHeight), foregroundImage);

        //the text that displays the current health over the max helth
        GUI.Label(new Rect(positionLeft, Screen.height - positionTop, textSize, barHeight), ((float)currentHydration / (float)maxHydration) * 100 + "%");
    }

    /// <summary>
    /// takes care of updating the bar
    /// </summary>
    private void AdjustCurrentValue()
    {
        //bounds checking
        if (currentHydration <= 0)
        {
            currentHydration = 0;
        }

        if (currentHydration >= maxHydration)
        {
            currentHydration = maxHydration;
        }

        if (maxHydration < 1)
        {
            maxHydration = 1;
        }

        //this is what controles the size of the bar in the horazontal direction
        valueBarLength = (screenSize) * (currentHydration / (float)maxHydration);
    }

    /// <summary>
    /// allows for another script to change the starting values of this bar
    /// </summary>
    /// <param name="newValue"></param>
    public void SetInitialValues(int newValue)
    {
        maxHydration = newValue;
        currentHydration = newValue;
    }

    /// <summary>
    /// sets the value of the bar
    /// does bounds checking on the value
    /// </summary>
    /// <param name="newValue"></param>
    public void SetCurrentValue(int newValue)
    {
        currentHydration = newValue;

        //does bounds checking on the new value
        AdjustCurrentValue();
    }
}
