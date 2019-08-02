using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HideMenuScript : MonoBehaviour
{

    public Canvas canvas;
    public MeshRenderer progressBar, playButton, ffButton;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean menuAction;
    private bool active = true;
    public GameObject videoUI;

    public void HideMenu()
    {
        if (menuAction.GetState(handType) && active)
        {
            videoUI.SetActive(false);
            active = false;
            /*canvas.gameObject.SetActive(false);
            progressBar.gameObject.SetActive(false);
            playButton.gameObject.SetActive(false);
            ffButton.gameObject.SetActive(false);*/
        }
        else
        {
            videoUI.SetActive(true);
            active = true;
            /*canvas.gameObject.SetActive(true);
            progressBar.gameObject.SetActive(true);
            playButton.gameObject.SetActive(true);
            ffButton.gameObject.SetActive(true);*/
        }
    }


}
