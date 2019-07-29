using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FastForward15s : MonoBehaviour {

    public WorldSpaceVideo worldSpaceVideo;
    public ScreenSpaceVideo leftScreenSpaceVideo, rightScreenSpaceVideo;

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;

    private void Update()
    {
        if (triggerAction.GetState(handType))
        {
            worldSpaceVideo.Forward15Seconds();
            leftScreenSpaceVideo.Forward15Seconds();
            rightScreenSpaceVideo.Forward15Seconds();
        }
    }

    void OnMouseDown()
    {
        worldSpaceVideo.Forward15Seconds();
        leftScreenSpaceVideo.Forward15Seconds();
        rightScreenSpaceVideo.Forward15Seconds();
    }
}
