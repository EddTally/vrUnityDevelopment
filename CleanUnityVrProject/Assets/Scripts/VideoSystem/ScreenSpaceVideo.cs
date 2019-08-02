using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ScreenSpaceVideo : MonoBehaviour
{

    private VideoPlayer videoPlayer;


    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public VideoPlayer GetVideoPlayer()
    {
        return videoPlayer;
    }

}
