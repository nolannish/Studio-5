using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private AudioClip brickDestroySound;
    [SerializeField] private AudioClip wallHitSound;
    [SerializeField] private AudioClip paddleHitSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
