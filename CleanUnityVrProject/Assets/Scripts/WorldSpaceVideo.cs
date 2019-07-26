using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class WorldSpaceVideo : MonoBehaviour {

    public Material playButtonMaterial;
    public Material pauseButtonMaterial;
    public Renderer playButtonRenderer;
    public Text currentMinutes, currentSeconds, totalMinutes, totalSeconds;
    public PlayHeadMover playHeadMover;

    private VideoPlayer videoPlayer;


    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Use this for initialization
    void Start () {
        SetTotalTimeUI();
        //videoPlayer.targetTexture.Release(); //Clears the last frame of video just played.
    }
	
	// Update is called once per frame
	void Update () {
        if (videoPlayer.isPlaying)
        {
            SetCurrentTimeUI();
            playHeadMover.MovePlayHead(CalculatePlayedFraction());
        }
	}

    public void PlayPause()
    {
        if (videoPlayer.isPlaying){
            videoPlayer.Pause();
            playButtonRenderer.material = playButtonMaterial;
        } else
        {
            videoPlayer.Play();
            playButtonRenderer.material = pauseButtonMaterial;
        }
    }

    public void Forward15Seconds()
    {
        videoPlayer.time = videoPlayer.time + 15;

    }


    void SetCurrentTimeUI()
    {
        string minutes = Mathf.Floor((int)videoPlayer.time / 60).ToString("00");
        string seconds = ((int)videoPlayer.time % 60).ToString("00");

        currentMinutes.text = minutes;
        currentSeconds.text = seconds;
    }

    void SetTotalTimeUI()
    {
        string minutes = Mathf.Floor((int)videoPlayer.clip.length / 60).ToString("00");
        string seconds = ((int)videoPlayer.clip.length % 60).ToString("00");

        totalMinutes.text = minutes;
        totalSeconds.text = seconds;
    }

    double CalculatePlayedFraction()
    {
        double fraction = (double)videoPlayer.frame / (double)videoPlayer.clip.frameCount;
        return fraction;
    }

}
