using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FastForwardScript : MonoBehaviour {

    public WorldSpaceVideo worldSpaceVideo;
    public ScreenSpaceVideo leftScreenSpaceVideo, rightScreenSpaceVideo;

    public void ff15s()
    {
        worldSpaceVideo.GetVideoPlayer().time += 15;
        leftScreenSpaceVideo.GetVideoPlayer().time += 15;
        rightScreenSpaceVideo.GetVideoPlayer().time += 15;
    }
}
