using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FFandRewindScript : MonoBehaviour {

    public WorldSpaceVideo worldSpaceVideo;
    public ScreenSpaceVideo leftScreenSpaceVideo, rightScreenSpaceVideo;

    public void FF15s()
    {
        worldSpaceVideo.GetVideoPlayer().time += 15;
        leftScreenSpaceVideo.GetVideoPlayer().time += 15;
        rightScreenSpaceVideo.GetVideoPlayer().time += 15;
    }

    public void FF30s() {
        worldSpaceVideo.GetVideoPlayer().time += 30;
        leftScreenSpaceVideo.GetVideoPlayer().time += 30;
        rightScreenSpaceVideo.GetVideoPlayer().time += 30;
    }

    public void FF1m()
    {
        worldSpaceVideo.GetVideoPlayer().time += 60;
        leftScreenSpaceVideo.GetVideoPlayer().time += 60;
        rightScreenSpaceVideo.GetVideoPlayer().time += 60;
    }

    public void Rewind15s()
    {
        worldSpaceVideo.GetVideoPlayer().time -= 15;
        leftScreenSpaceVideo.GetVideoPlayer().time -= 15;
        rightScreenSpaceVideo.GetVideoPlayer().time -= 15;
    }

    public void Rewind30s()
    {
        worldSpaceVideo.GetVideoPlayer().time -= 30;
        leftScreenSpaceVideo.GetVideoPlayer().time -= 30;
        rightScreenSpaceVideo.GetVideoPlayer().time -= 30;
    }

    public void Rewind1m()
    {
        worldSpaceVideo.GetVideoPlayer().time -= 60;
        leftScreenSpaceVideo.GetVideoPlayer().time -= 60;
        rightScreenSpaceVideo.GetVideoPlayer().time -= 60;
    }
}
