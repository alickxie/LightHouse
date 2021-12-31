using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    // Set up different varaibles
    public Slider slider;        // Input the slider component
    public Image[] LuminosityPoints;

    // Function to set the slider bar to its maxmium value
    public void SetMaxLuminosity(float Luminosity)
    {
        slider.maxValue = Luminosity;
        slider.value = Luminosity;
    }

    // Update the current slider value for display
    public void SetLuminosity(float Luminosity)
    {
        slider.value = Luminosity;

        for (int i = 0; i < LuminosityPoints.Length; i++)
        {
            LuminosityPoints[i].enabled = !DisplayLuminosityPoint(Luminosity, i);
        }
    }

    bool DisplayLuminosityPoint(float Luminosity, int pointNumber)
    {
        return ( (pointNumber * 10) >= (Luminosity/161f)*100 );
    }

}
