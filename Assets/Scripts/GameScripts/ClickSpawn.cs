using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSpawn : MonoBehaviour
{
    public GameObject Cube;
    private int flashNum = 0;
    Text flashNumText;

    void Start()
    {
        flashNumText = GameObject.Find("FlashNumText").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            if (flashNum < 3)
            {
                Instantiate(Cube, new Vector3(worldPosition[0], worldPosition[1] + 10, worldPosition[2]), Quaternion.identity);
                flashNum++;
                flashNumText.text = flashNum + "/3";
            }
        }
    }
}
