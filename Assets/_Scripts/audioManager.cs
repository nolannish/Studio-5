using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip brickDestroySound;
    [SerializeField] private AudioClip wallHitSound;
    [SerializeField] private AudioClip paddleHitSound;
    [SerializeField] private AudioClip backgroundMusic; // New background music clip

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBackgroundMusic(); // Start playing background music
    }

    public void PlayBrickDestroySound()
    {
        audioSource.PlayOneShot(brickDestroySound);
    }

    public void PlayWallHitSound()
    {
        audioSource.PlayOneShot(wallHitSound);
    }

    public void PlayPaddleHitSound()
    {
        audioSource.PlayOneShot(paddleHitSound);
    }

    private void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Enable looping
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
