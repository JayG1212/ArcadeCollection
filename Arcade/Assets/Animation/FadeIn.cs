using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineFadeOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("The Animator on the Outline Image")]
    public Animator outlineAnimator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        outlineAnimator.ResetTrigger("Exit"); // In case it's fading out
        outlineAnimator.SetTrigger("Hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outlineAnimator.ResetTrigger("Hover");
        outlineAnimator.SetTrigger("Exit");
    }
}
