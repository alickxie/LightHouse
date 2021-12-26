using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheGate : MonoBehaviour
{
    public int pin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (StarAction.starNumValue == pin)
        {
            Destroy(this.gameObject);
        }
    }
}
