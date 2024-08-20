
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public enum SoundType
{
    EnemyExplosion,
    MainMenuMusic,
    GameMusic,
    Shoot,
    AppleSFX,
    TomatoSFX,

    CarrotSFX,
    HoverUISFX,
    ClickUISFX,
    BossExplosion,
    BossSpawn,
    EatingSFX,

}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private AudioSource audioSource;
    public static SoundManager instance;

    public AudioMixer gameMixer;
    public Slider musicSlider;
    public Slider effectsSlider;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }

    public void PlayHoverSound()
    {
        PlaySound(SoundType.HoverUISFX, 0.15f);
    }

    public void PlayClickSound()
    {
        PlaySound(SoundType.ClickUISFX, 0.15f);
    }

    public void MusicVolume()
    {
        float volume = musicSlider.value;
        gameMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }

    public void EffectsVolume()
    {
        float volume = effectsSlider.value;
        gameMixer.SetFloat("effects", Mathf.Log10(volume) * 20);
    }

}
