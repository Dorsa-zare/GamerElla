using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ImageAppear; 
    public void OnPointerEnter(PointerEventData eventData)
    {
        ImageAppear.SetActive(true); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImageAppear.SetActive(false);
    }
}
