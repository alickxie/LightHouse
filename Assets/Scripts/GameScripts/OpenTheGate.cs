using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheGate : MonoBehaviour
{
    public int pin;
    
    void Update()
    {
        if (StarAction.starNumValue == pin)
        {
            transform.position += new Vector3(0, 30 * Time.deltaTime, 0);
            openTheGate();
        }
    }

    public void openTheGate()
    {
        StartCoroutine(openTheGateTransition());
    }

    IEnumerator openTheGateTransition()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(this.gameObject);
    }
}
