using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ScreenSpaceVideo : MonoBehaviour
{

    public Material playButtonMaterial;
    public Material pauseButtonMaterial;
    public Renderer playButtonRenderer;
    private VideoPlayer videoPlayer;


    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public void PlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            playButtonRenderer.material = playButtonMaterial;
        }
        else
        {
            videoPlayer.Play();
            playButtonRenderer.material = pauseButtonMaterial;
        }
    }

    public void Skip15Seconds()
    {
        videoPlayer.time = videoPlayer.time + 15;
    }

}
