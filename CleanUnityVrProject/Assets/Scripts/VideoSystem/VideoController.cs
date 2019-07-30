using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VideoController : MonoBehaviour
{

    public WorldSpaceVideo worldSpaceVideo; //worldSpaceVideo1, worldSpaceVideo2;
    public ScreenSpaceVideo leftScreenSpaceVideo, rightScreenSpaceVideo;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;
    
    public Collider forwardCollider;

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerAction.GetState(handType) && forwardCollider.gameObject.name == "FastForwardButton")
        {
            playPause();
        }
    }

    void playPause()
    {
        worldSpaceVideo.PlayPause();
        leftScreenSpaceVideo.PlayPause();
        rightScreenSpaceVideo.PlayPause();
    }
}
