using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameManager manager;
    public GameObject[] ImageAppear; 
    [SerializeField] private string option;

    void Start()
    {
        manager = GameManager.Instance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (GameObject image in ImageAppear) image.SetActive(true); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (GameObject image in ImageAppear) image.SetActive(false);
    }

    void OnMouseDown()
    {
        manager.AddPoints(option, 2);
    }
}
