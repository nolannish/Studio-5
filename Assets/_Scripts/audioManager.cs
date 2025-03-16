using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("Audio Clips")]

    //audio clips
    [SerializeField] private AudioClip brickDestroySound;
    [SerializeField] private AudioClip wallHitSound;
    [SerializeField] private AudioClip paddleHitSound;
    [SerializeField] private AudioClip backgroundMusic; 
    [SerializeField] private AudioClip launchSound; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       //PlayLaunchSound(); // Play launch sound when the scene starts
        PlayBackgroundMusic(); // on start of scene begin background music
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

    public void PlayLaunchSound()
    {
        audioSource.PlayOneShot(launchSound);
    }

    private void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Once song ends, will repeat... forever
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
