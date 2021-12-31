using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveZone : MonoBehaviour
{
    private LightRange lightRange;

    // Start is called before the first frame update
    void Start()
    {
        lightRange = GameObject.Find("LampLight").GetComponent<LightRange>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lightRange.decreaseLight = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lightRange.decreaseLight = true;
        }
    }
}
