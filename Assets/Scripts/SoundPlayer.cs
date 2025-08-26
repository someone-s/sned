using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;

    private float effectVolume = 1f;

    [SerializeField] private AudioClip[] effects;

    private void Awake()
    {
        if (Instance != null)
        {
            musicSource.enabled = false;
            effectSource.enabled = false;
            gameObject.name += " (Temporary)";
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.name += " (Persistent)";
        }
    }

    public void SetMusicVolume(float level)
    {
        Instance.musicSource.volume = level;
    }

    public void SetEffectSource(float level)
    {
        Instance.effectVolume = level;
    }

    public void PlayEffect(int index)
    {
        Instance.effectSource.PlayOneShot(Instance.effects[index], Instance.effectVolume);
    }
}
