using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameConditions : MonoBehaviour
{
    private GameObject gameoverMenu;
    private GameObject victoryMenu;
    private LightRange lightRange;

    // Start is called before the first frame update
    void Start()
    {
        gameoverMenu = GameObject.Find("GameOverMenu");
        victoryMenu = GameObject.Find("VictoryMenu");
        gameoverMenu.SetActive(false);
        victoryMenu.SetActive(false);

        lightRange = GameObject.Find("LampLight").GetComponent<LightRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightRange.lightRange.innerSpotAngle <= 0)
        {
            gameoverMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            victoryMenu.SetActive(true);
        }
    }
}
