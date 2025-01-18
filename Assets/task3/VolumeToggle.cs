using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeToggle : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private List<ToggleVolumePair> _toggleVolumePairs;

    private float _muteVolume = -80f;
    private float _defaultVolume = 0f;

    private void Start()
    {
        foreach (ToggleVolumePair pair in _toggleVolumePairs)
        {
            pair.Toggle.isOn = true;
            pair.Toggle.onValueChanged.AddListener(isOn => ToggleVolume(pair.VolumeParameter, isOn));
        }
    }

    private void ToggleVolume(string volumeParameter, bool isOn)
    {
        if (isOn)
        {
            _mixer.SetFloat(volumeParameter, _defaultVolume);
        }
        else
        {
            _mixer.SetFloat(volumeParameter, _muteVolume);
        }
    }
}

[System.Serializable]
public class ToggleVolumePair
{
    public Toggle Toggle;
    public string VolumeParameter;
}