using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRange : MonoBehaviour
{
    public Light lightRange;
    public TimeBar timeBar;
    public bool increaseLight;
    public bool decreaseLight;
    public int increaseMutiplier;
    public int decreaseMutiplier;
    float counter;
    float decreaseCounter;

    // Start is called before the first frame update
    void Start()
    {
        increaseLight = false;
        decreaseLight = false;
        lightRange = GameObject.Find("LampLight").GetComponent<Light>();
        decreaseCounter = 3f;
        timeBar.SetMaxLuminosity(161f);
        timeBar.SetLuminosity(lightRange.innerSpotAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseLight)
        {
            if (lightRange.spotAngle <= 179)
            {
                lightRange.innerSpotAngle += Time.deltaTime * increaseMutiplier;
                lightRange.spotAngle += Time.deltaTime * increaseMutiplier;
                timeBar.SetLuminosity(lightRange.innerSpotAngle);
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
                    lightRange.innerSpotAngle -= Time.deltaTime * decreaseMutiplier;
                    lightRange.spotAngle -= Time.deltaTime * decreaseMutiplier;
                    decreaseCounter = 4f;
                    timeBar.SetLuminosity(lightRange.innerSpotAngle);
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
