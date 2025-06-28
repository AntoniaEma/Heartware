using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [Header("Audio Clips")]
    public AudioClip damageSound;
    public AudioClip collectSound;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlayDamageSound()
    {
        if (damageSound != null)
            audioSource.PlayOneShot(damageSound);
    }

    public void PlayCollectSound()
    {
        if (collectSound != null)
            audioSource.PlayOneShot(collectSound);
    }
}
