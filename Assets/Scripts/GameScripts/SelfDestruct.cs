using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private Light FlashLight;
    public int DurationTime;
    float counter = 0;

    void Start()
    {
        FlashLight = this.gameObject.GetComponent<Light>();
    }

    void Update()
    {
        counter += Time.deltaTime;

        FlashLight.range -= Time.deltaTime/10;

        if (counter >= DurationTime)
        {
            Destroy(this.gameObject);
        }
    }
}
