using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayPauseController : MonoBehaviour
{

    public WorldSpaceVideo worldSpaceVideo; //worldSpaceVideo1, worldSpaceVideo2;
    public ScreenSpaceVideo leftScreenSpaceVideo, rightScreenSpaceVideo;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Controller (left)" || col.gameObject.name == "Controller (right)")
        {
            worldSpaceVideo.PlayPause();
            leftScreenSpaceVideo.PlayPause();
            rightScreenSpaceVideo.PlayPause();
        }
    }

    void Update()
    {
        if (triggerAction.GetState(handType))
        {
            worldSpaceVideo.PlayPause();
            leftScreenSpaceVideo.PlayPause();
            rightScreenSpaceVideo.PlayPause();
        }
    }

    void OnMouseDown()
    {
        worldSpaceVideo.PlayPause();
        leftScreenSpaceVideo.PlayPause();
        rightScreenSpaceVideo.PlayPause();
        //worldSpaceVideo1.PlayPause();
        //worldSpaceVideo2.PlayPause();
    }
}
