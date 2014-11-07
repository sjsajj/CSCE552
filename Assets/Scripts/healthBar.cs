﻿using UnityEngine;
using System.Collections;

//displays a horizontal bar with a max and min value which will appear in text on the bar
public class healthBar : MonoBehaviour
{
    //values for the bar
    private int maxHealth = 100;
    private int currentHealth = 100;

    // use this to control how much space the value read out has
    public int textSize = 50;

    //positioning the bar
    public int positionTop = 30;
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
        GUI.Label(new Rect(positionLeft, Screen.height - positionTop, textSize, barHeight), currentHealth + "/" + maxHealth);
    }

    /// <summary>
    /// takes care of updating the bar
    /// </summary>
    public void AdjustCurrentValue()
    {
        //bounds checking
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (maxHealth < 1)
        {
            maxHealth = 1;
        }

        //this is what controles the size of the bar in the horazontal direction
        valueBarLength = (screenSize) * (currentHealth / (float)maxHealth);
    }

    /// <summary>
    /// allows for another script to change the starting values of this bar
    /// </summary>
    /// <param name="newValue"></param>
    public void SetInitialValues(int newValue)
    {
        maxHealth = newValue;
        currentHealth = newValue;
    }

    /// <summary>
    /// sets the value of the bar
    /// does bounds checking on the value
    /// </summary>
    /// <param name="newValue"></param>
    public void SetCurrentValue(int newValue)
    {
        currentHealth = newValue;

        //does bounds checking on the new value
        AdjustCurrentValue();
    }
}
