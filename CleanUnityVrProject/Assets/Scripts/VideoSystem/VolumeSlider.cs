using UnityEngine;
public class VolumeSlider : MonoBehaviour
{
    /* www.answers.unity.com/questions/1111955/how-do-i-make-a-change-a-volume-with-a-slider.html */
    public UnityEngine.UI.Slider slider;
    public UnityEngine.Audio.AudioMixer mixer;
    public string parameterName;

    void Awake()
    {
        float savedVol = PlayerPrefs.GetFloat(parameterName, slider.maxValue);
        SetVolume(savedVol); //Manually set value & volume before subscribing to ensure it is set even if slider.value happens to start at the same value as is saved
        slider.value = savedVol;
        slider.onValueChanged.AddListener((float _) => SetVolume(_)); //UI classes use unity events, requiring delegates (delegate(float _) { SetVolume(_); }) or lambda expressions ((float _) => SetVolume(_))
    }

    void SetVolume(float _value)
    {
        mixer.SetFloat(parameterName, ConvertToDecibel(_value / slider.maxValue)); //Dividing by max allows arbitrary positive slider maxValue
        PlayerPrefs.SetFloat(parameterName, _value);
    }

    /// <summary>
    /// Converts a percentage fraction to decibels,
    /// with a lower clamp of 0.0001 for a minimum of -80dB, same as Unity's Mixers.
    /// </summary>
    public float ConvertToDecibel(float _value)
    {
        return Mathf.Log10(Mathf.Max(_value, 0.0001f)) * 20f;
    }
}