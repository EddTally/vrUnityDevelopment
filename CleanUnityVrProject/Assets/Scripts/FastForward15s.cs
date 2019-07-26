using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForward15s : MonoBehaviour {

    public WorldSpaceVideo worldSpaceVideo, worldSpaceVideo1, worldSpaceVideo2;
    void OnMouseDown()
    {
        worldSpaceVideo.Forward15Seconds();
        worldSpaceVideo1.Forward15Seconds();
        worldSpaceVideo2.Forward15Seconds();
    }
}
