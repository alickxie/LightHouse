using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTransition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public int floorIndex;
    public GameObject floor2Cam;
    public GameObject floor1Cam;
    public GameObject floor0Cam;

    TextMeshProUGUI FloorName;

    GameObject player;
    static bool second = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        floor0Cam.SetActive(false);
        floor1Cam.SetActive(true);
        floor2Cam.SetActive(false);
        FloorName = GameObject.Find("FloorName").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeFloor();
        }
    }

    public void ChangeFloor()
    {
        StartCoroutine(FloorTransition(floorIndex));
    }

    IEnumerator FloorTransition(int floorIndex)
    {
        transition.SetTrigger("Start");

        if (floorIndex == 1)
        {
            transition.SetBool("Transitioning", true);
            yield return new WaitForSeconds(transitionTime);

            FloorName.SetText("Floor -1");
            player.transform.localPosition = new Vector3(-3.4f, 0.51f, 24.95f);
            player.transform.localRotation = Quaternion.Euler(0, 0, 0);
            floor0Cam.SetActive(true);
            floor1Cam.SetActive(false);
            floor2Cam.SetActive(false);
        }
        else if (floorIndex == 0)
        {
            transition.SetBool("Transitioning", false);
            yield return new WaitForSeconds(transitionTime);

             FloorName.SetText("Floor 1");
            if (second)
            {
                player.transform.localPosition = new Vector3(3.53f, 0.51f, -3.49f);
                player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                second = false;
            }
            else
            {
                player.transform.localPosition = new Vector3(-4.53f, 0.51f, -0.71f);
                player.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            floor0Cam.SetActive(false);
            floor1Cam.SetActive(true);
            floor2Cam.SetActive(false);
        }
        else if (floorIndex == 2)
        {
            second = true;
            transition.SetBool("Transitioning", true);
            yield return new WaitForSeconds(transitionTime);

            FloorName.SetText("Floor 2");
            player.transform.localPosition = new Vector3(2.09f, 0.51f, -19.03f);
            player.transform.localRotation = Quaternion.Euler(0, 0, 0);
            floor0Cam.SetActive(false);
            floor1Cam.SetActive(false);
            floor2Cam.SetActive(true);
        }
    }
}
