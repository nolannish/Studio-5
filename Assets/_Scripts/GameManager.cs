using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] public int maxLives = 3;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;

    [SerializeField] public static int score = 0;
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private LivesCounter livesCounter;
    [SerializeField] private float shakeDuration = 0.1f; // How long the camera shake lasts
    [SerializeField] private float shakeIntensity = 0.2f; // How strong the camera shake is
    [SerializeField] private GameObject gameOverMenu;


    private int currentBrickCount;
    private int totalBrickCount;
    private Camera mainCamera;
    private Vector3 originalCameraPosition;
    public bool isGameOverMenuActive;

    protected override void Awake()
    {
        base.Awake();
        isGameOverMenuActive = false;

        // Ensure gameOverMenu is hidden at the beginning
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false);
        }
    }

    private void OnEnable()
    {
        InputHandler.Instance.OnFire.AddListener(FireBall);
        ball.ResetBall();
        totalBrickCount = bricksContainer.childCount;
        currentBrickCount = bricksContainer.childCount;
    }

    private void OnDisable()
    {
        InputHandler.Instance.OnFire.RemoveListener(FireBall);
    }

    private void FireBall()
    {
        ball.FireBall();
    }

    public void OnBrickDestroyed(Vector3 position)
    {
        // fire audio here
        // implement particle effect here
        // add camera shake here
        StartCoroutine(ShakeCamera());

        currentBrickCount--;
        score++;
        scoreCounter.UpdateScore(score);
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");
        if(currentBrickCount == 0) SceneHandler.Instance.LoadNextScene();
    }

    public void KillBall()
    {
        maxLives--;
        // update lives on HUD here
        // game over UI if maxLives < 0, then exit to main menu after delay
        livesCounter.UpdateLives(maxLives);
        Debug.Log("lives" + maxLives);
        if(maxLives < 1){
            GameOver();
        }
        ball.ResetBall();
    }

    public void GameOver(){
        Time.timeScale = 0f;
        isGameOverMenuActive = true;
        // Ensure the gameOverMenu is enabled when the game is over
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);
            StartCoroutine(GameOverWait());
        }
    }

    private IEnumerator GameOverWait(){
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 1f;
        SceneHandler.Instance.LoadMenuScene();
    }
    private IEnumerator ShakeCamera()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.LogError("No Main Camera found in the scene!");
                yield break;
            }
            originalCameraPosition = mainCamera.transform.localPosition;
        }
        else if (originalCameraPosition == Vector3.zero)
        {
            originalCameraPosition = mainCamera.transform.localPosition;
        }

        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeIntensity;
            float y = Random.Range(-1f, 1f) * shakeIntensity;
            Vector3 offset = new Vector3(x, y, 0f);

            mainCamera.transform.localPosition = originalCameraPosition + offset;

            elapsed += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.localPosition = originalCameraPosition;
    }
}