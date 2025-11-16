using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameManager manager;
    public GameObject[] ImageAppear; 
    [SerializeField] private string option;

    // Public variable to set the target scene index in the Inspector
    public int sceneIndex = 2;

    void Start()
    {
        manager = GameManager.Instance;
        if (manager == null)
        {
            Debug.LogError("Hover: GameManager instance not found.");
        }
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
        // Check if manager exists
        if (manager != null)
        {
            manager.AddPoints(option, 2);
            SceneManager.LoadSceneAsync(sceneIndex);
        }
        else
        {
            Debug.LogWarning("GameManager is not available!");
        }
    }
}