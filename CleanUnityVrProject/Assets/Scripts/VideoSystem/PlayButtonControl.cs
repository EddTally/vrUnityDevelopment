using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonControl : MonoBehaviour
{

    public WorldSpaceVideo worldSpaceVideo; //worldSpaceVideo1, worldSpaceVideo2;
    public ScreenSpaceVideo leftScreenSpaceVideo, rightScreenSpaceVideo;
 

    void OnMouseDown()
    {
        worldSpaceVideo.PlayPause();
        leftScreenSpaceVideo.PlayPause();
        rightScreenSpaceVideo.PlayPause();
        //worldSpaceVideo1.PlayPause();
        //worldSpaceVideo2.PlayPause();
    }

}
