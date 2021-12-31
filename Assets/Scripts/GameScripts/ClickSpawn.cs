using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickSpawn : MonoBehaviour
{
    public GameObject Cube;
    private int flashNum = 0;
    TextMeshProUGUI flashNumText;

    void Start()
    {
        flashNumText = GameObject.Find("FlashNumText").GetComponent<TextMeshProUGUI>();
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
                flashNumText.text = flashNum + " / 3";
            }
        }
    }
}
