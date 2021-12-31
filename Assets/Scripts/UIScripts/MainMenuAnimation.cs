using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
    public Animator titleLogo;
    public Animator clickToStart;
    public Animator cameraTransition;
    public Animator playButtonFade;
    public Animator optionButtonFade;
    public Animator quitButtonFade;
    public Animator volumnMenuFade;
    public Animator lightTransition;
    public Animator DarkTransition;
    public float transitionTime;
    public GameObject clickToStartObj;
    public GameObject playButton;
    public GameObject optionButton;
    public GameObject quitButton;

    // Start is called before the first frame update
    void Start()
    {
        titleLogo.SetBool("MouseCliked", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickToStart()
    {
        StartCoroutine(ClickTransition());
    }

    public void VolumnTransition()
    {
        volumnMenuFade.SetBool("Enter", true);
    }

    public void LeavevVolumnTransition()
    {
        playButtonFade.SetBool("Enter", true);
        optionButtonFade.SetBool("Enter", true);
        quitButtonFade.SetBool("Enter", true);
    }

    public void GameStart()
    {
        StartCoroutine(GameStartTransition());
    }

    IEnumerator ClickTransition()
    {
        titleLogo.SetBool("MouseCliked", true);
        clickToStart.SetBool("StartClicked", true);

        yield return new WaitForSeconds(transitionTime);
        cameraTransition.SetBool("Enter", true);
        clickToStartObj.SetActive(false);
        playButton.SetActive(true);
        optionButton.SetActive(true);
        quitButton.SetActive(true);

        yield return new WaitForSeconds(transitionTime + 0.4f);
        playButtonFade.SetBool("Enter", true);
        optionButtonFade.SetBool("Enter", true);
        quitButtonFade.SetBool("Enter", true);
    }
    IEnumerator GameStartTransition()
    {
        lightTransition.SetBool("Enter", true);
        DarkTransition.SetBool("Enter", true);
        yield return new WaitForSeconds(transitionTime + 0.3f);
        cameraTransition.SetBool("Transition", true);
    }


}
