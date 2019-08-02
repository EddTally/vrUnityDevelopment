using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR;

public class PlayPauseScript : MonoBehaviour
{

    public WorldSpaceVideo worldSpaceVideo; //worldSpaceVideo1, worldSpaceVideo2;
    public ScreenSpaceVideo leftScreenSpaceVideo, rightScreenSpaceVideo;
    public Material playButtonMaterial;
    public Material pauseButtonMaterial;
    public Renderer playButtonRenderer;

    public void PlayPause()
    {
        if (worldSpaceVideo.GetVideoPlayer().isPlaying &&
            leftScreenSpaceVideo.GetVideoPlayer().isPlaying &&
            rightScreenSpaceVideo.GetVideoPlayer().isPlaying)
        {
            worldSpaceVideo.GetVideoPlayer().Pause();
            leftScreenSpaceVideo.GetVideoPlayer().Pause();
            rightScreenSpaceVideo.GetVideoPlayer().Pause();
            playButtonRenderer.material = playButtonMaterial;
        }
        else
        {
            worldSpaceVideo.GetVideoPlayer().Play();
            leftScreenSpaceVideo.GetVideoPlayer().Play();
            rightScreenSpaceVideo.GetVideoPlayer().Play(); ;
            playButtonRenderer.material = pauseButtonMaterial;
        }
    }

    void OnMouseDown()
    {
        PlayPause();
    }
}
