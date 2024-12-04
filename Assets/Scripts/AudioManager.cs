using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicSource;
    public AudioSource soundEffectSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        Debug.Log("Music volume set to: " + volume);
    }

    public void SetSoundEffectVolume(float volume)
    {
        soundEffectSource.volume = volume;
        Debug.Log("Sound effect volume set to: " + volume);
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.loop = true; // Lặp lại nhạc nền
            musicSource.Play();
        }
    }

}

