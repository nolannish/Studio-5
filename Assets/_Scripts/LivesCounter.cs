using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform livesTextContainer;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;
    
    private float containerInitPosition;
    private float moveAmount;
    void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("3");
        toUpdate.SetText("3");
        containerInitPosition = livesTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int maxLives){
        toUpdate.SetText($"{maxLives}");
        livesTextContainer.DOLocalMoveY(containerInitPosition - moveAmount, duration).SetEase(animationCurve);
    }

    private IEnumerator ResetLivesContainer(int maxLives){
        yield return new WaitForSeconds(duration);
        current.SetText($"{maxLives}");
        Vector3 localPosition = livesTextContainer.localPosition;
        livesTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
    }
}
