using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForward15s : MonoBehaviour {

    public WorldSpaceVideo worldSpaceVideo, worldSpaceVideo1, worldSpaceVideo2;
    void OnMouseDown()
    {
        worldSpaceVideo.Skip15Seconds();
        worldSpaceVideo1.Skip15Seconds();
        worldSpaceVideo2.Skip15Seconds();
        //leftWorldSpaceVideo.PlayPause();
    }
}
