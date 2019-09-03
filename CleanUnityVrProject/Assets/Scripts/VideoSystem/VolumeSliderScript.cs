using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderScript : MonoBehaviour
{
    /* https://answers.unity.com/questions/1111955/how-do-i-make-a-change-a-volume-with-a-slider.html */
    public Slider slider;
    public AudioMixer mixer;
    public string parameterName;

    void Awake()
    {
        slider.onValueChanged.AddListener((float _) => SetVolume(_));
    }

    public void SetVolume(float _value)
    {
        if (slider.IsActive())
        {
            mixer.SetFloat(parameterName, ConvertToDecibel(_value / slider.maxValue)); //Dividing by max allows arbitrary positive slider maxValue
        }
    }

    /// <summary>
    /// Converts a percentage fraction to decibels,
    /// with a lower clamp of 0.0001 for a minimum of -80dB, same as Unity's Mixers.
    /// </summary>
    public float ConvertToDecibel(float _value)
    {
        return Mathf.Log10(Mathf.Max(_value, 0.0001f)) * 20f;
    }

    public void HideVolumeSlider()
    {
        if (slider.IsActive())
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.gameObject.SetActive(true);
        }
    }
    public void IncreaseVolume()
    {
        if (slider.IsActive())
        {
            slider.value += 0.01f;
        }
    }

    public void DecreaseVolume()
    {
        if (slider.IsActive())
        {
            slider.value -= 0.01f;
        }
    }

}