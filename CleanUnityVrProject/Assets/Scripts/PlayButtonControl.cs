using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonControl : MonoBehaviour
{

    public WorldSpaceVideo worldSpaceVideo, worldSpaceVideo1, worldSpaceVideo2;
    //public LeftWorldSpaceVideo leftWorldSpaceVideo;

    void OnMouseDown()
    {
        worldSpaceVideo.PlayPause();
        worldSpaceVideo1.PlayPause();
        worldSpaceVideo2.PlayPause();
        //leftWorldSpaceVideo.PlayPause();
    }

}
