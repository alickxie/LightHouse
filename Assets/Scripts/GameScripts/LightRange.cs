using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRange : MonoBehaviour
{
    public Light lightRange;
    public bool increaseLight;
    public bool decreaseLight;
    // private static LTDescr delay;
    float counter;
    private float decreaseCounter;

    // Start is called before the first frame update
    void Start()
    {
        increaseLight = false;
        decreaseLight = false;
        lightRange = GameObject.Find("LampLight").GetComponent<Light>();
        decreaseCounter = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseLight)
        {
            if (lightRange.spotAngle <= 179)
            {
                lightRange.innerSpotAngle += Time.deltaTime * 40;
                lightRange.spotAngle = lightRange.innerSpotAngle + 17.148f;
            }

            if (counter < 1)
            {
                counter += Time.deltaTime;
            }

            Reset();

        }
        else
        {
            if (lightRange.innerSpotAngle >= 0 && decreaseLight)
            {
                if (decreaseCounter >= 0)
                {
                    lightRange.innerSpotAngle -= Time.deltaTime * 5;
                    lightRange.spotAngle = lightRange.innerSpotAngle + 17.148f;
                    decreaseCounter = 4f;
                }
                decreaseCounter -= Time.deltaTime;
            }
        }
    }

    private void Reset()
    {
        if (counter > 1f)
        {
            increaseLight = false;
            counter = 0;
        }
    }
}
