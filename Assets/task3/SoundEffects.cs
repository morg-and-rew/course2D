using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private List<ButtonSoundPair> _soundButtonPairs;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.outputAudioMixerGroup = _mixerGroup;

        foreach (ButtonSoundPair pair in _soundButtonPairs)
        {
            pair.Button.onClick.AddListener(() => PlaySound(pair.Clip));
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}

[System.Serializable]
public class ButtonSoundPair
{
    public Button Button;
    public AudioClip Clip;
}