using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : AudioUtils
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private List<SliderSoundPair> _sliderSoundPairs;
    [SerializeField] private List<ToggleVolumePair> _toggleVolumePairs; 

    private void Start()
    {
        foreach (SliderSoundPair pair in _sliderSoundPairs)
        {
            pair.Slider.onValueChanged.AddListener(volume => SetVolume(pair.VolumeParameter, volume));
            SetVolume(pair.VolumeParameter, pair.Slider.value);
        }
    }

    public void SetVolume(string volumeParameter, float volume)
    {
        bool isToggleOn = IsToggleOn(volumeParameter);

        if (isToggleOn)
        {
            _mixer.SetFloat(volumeParameter, ConvertVolumeToDb(volume));
        }
    }

    private bool IsToggleOn(string volumeParameter)
    {
        foreach (ToggleVolumePair pair in _toggleVolumePairs)
        {
            if (pair.VolumeParameter == volumeParameter)
            {
                return pair.Toggle.isOn;
            }
        }

        return false; 
    }
}

[System.Serializable]
public class SliderSoundPair
{
    public Slider Slider;
    public string VolumeParameter;
}