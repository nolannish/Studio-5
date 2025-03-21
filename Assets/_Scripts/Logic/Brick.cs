using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject brickParticle;
    private Coroutine destroyRoutine = null;
    private audioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<audioManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (destroyRoutine != null) return;
        if (!other.gameObject.CompareTag("Ball")) return;
        destroyRoutine = StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(0.1f); // two physics frames to ensure proper collision
        audioManager.PlayBrickDestroySound();
        GameManager.Instance.OnBrickDestroyed(transform.position);
        // GameManager.Instance.IncrementScore();
        Destroy(gameObject);
        Instantiate(brickParticle, transform.position, transform.rotation);
    }
}
