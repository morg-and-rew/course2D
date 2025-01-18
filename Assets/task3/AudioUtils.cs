using UnityEngine;

public class AudioUtils : MonoBehaviour
{
    private float _volumeToDbScalingFactor = 20f;

    public float ConvertVolumeToDb(float volume)
    {
        return Mathf.Log10(volume) * _volumeToDbScalingFactor;
    }
}