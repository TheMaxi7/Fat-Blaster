using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        PlaySound(SoundType.HoverUISFX, 0.08f);
    }

    public void PlayClickSound()
    {
        PlaySound(SoundType.ClickUISFX, 0.08f);
    }


}
