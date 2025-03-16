using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private audioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<audioManager>();
    }

   //play sound when mouse is over play button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.CompareTag("Button"))
        {
            audioManager.PlayButtonHoverSound();
        }
    }

    //play sound when mouse is clicked on play button
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.CompareTag("Button"))
        {
            audioManager.PlayButtonClickSound();
        }
    }
}
