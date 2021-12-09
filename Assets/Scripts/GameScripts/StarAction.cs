using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAction : MonoBehaviour
{
    // Set the variables
    float speed = 5;
    bool wasCollected;
    Text starNumText;
    public static int starNumValue = 0;
    public LightRange lightRange;

    void Start()
    {
        wasCollected = false;
        starNumText = GameObject.Find("StarNumText").GetComponent<Text>();
        lightRange = GameObject.Find("LampLight").GetComponent<LightRange>();
    }

    // Update is called once per frame
    void Update()
    {
        // Let the star rotate around
        transform.Rotate(new Vector3(0, 0, 30) * speed * Time.deltaTime);
        // When the star is collected, it shrink a little, then disapear
        if (wasCollected)
        {
            Destroy(this.gameObject);
        }
    }

    // When player collect the star, it get score update on the UI
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            wasCollected = true;
            lightRange.increaseLight = true;
            starNumValue ++;
            starNumText.text = starNumValue + "/3";
        }
    }
}
