using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HideMenu : MonoBehaviour
{

    public Canvas canvas;
    public MeshRenderer progressBar, playButton, ffButton;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean menuAction;
    private bool active = true;

    private void Update()
    {
        if (menuAction.GetState(handType) && active)
        {
            canvas.gameObject.SetActive(false);
            progressBar.gameObject.SetActive(false);
            playButton.gameObject.SetActive(false);
            ffButton.gameObject.SetActive(false);
            active = false;
        }
        else
        {
            canvas.gameObject.SetActive(true);
            progressBar.gameObject.SetActive(true);
            playButton.gameObject.SetActive(true);
            ffButton.gameObject.SetActive(true);
        }
    }


}
