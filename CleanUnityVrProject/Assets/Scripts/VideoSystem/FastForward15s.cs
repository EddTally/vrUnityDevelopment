using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForward15s : MonoBehaviour {

    public WorldSpaceVideo worldSpaceVideo;
    public ScreenSpaceVideo screenSpaceVideo1, screenSpaceVideo2;
    void OnMouseDown()
    {
        worldSpaceVideo.Forward15Seconds();
        screenSpaceVideo1.Forward15Seconds();
        screenSpaceVideo2.Forward15Seconds();
    }
}
