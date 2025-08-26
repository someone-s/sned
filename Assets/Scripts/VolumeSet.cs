using UnityEngine;
using UnityEngine.UI;

public class VolumeSet : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
    }

    public void SetMusicVolume(float level)
    {
        SoundPlayer.Instance.SetMusicVolume(level);
    }

    public void SetEffectsVolume(float level)
    {
        SoundPlayer.Instance.SetMusicVolume(level);
    }
}
