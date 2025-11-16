using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class changeScenes : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private GameManager manager;
    private SliderScript sliderScript;
    public GameObject ImageAppear; 
    public int sceneIndex = 4;
    
    void Start()
    {
        manager = GameManager.Instance;
        if (manager == null)
        {
            Debug.LogError("Hover: GameManager instance not found.");
        }

        // Automatically find SliderScript in the scene
        sliderScript = FindFirstObjectByType<SliderScript>();
        
        if (sliderScript != null)
        {
            Debug.Log("SliderScript found!");
        }
        else
        {
            Debug.LogWarning("SliderScript not found in this scene.");
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (manager != null)
        {
            // Get the current option from the slider
            if (sliderScript != null)
            {
                string chosenOption = sliderScript.GetCurrentOption();
                manager.AddPoints(chosenOption, 2);
                SceneManager.LoadSceneAsync(sceneIndex);
                Debug.Log($"Added 2 points to {chosenOption}, loading scene {sceneIndex}");
            }
            else
            {
                Debug.LogError("Cannot proceed - SliderScript not found in scene!");
            }
        }
        else
        {
            Debug.LogWarning("GameManager is not available!");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ImageAppear != null)
        {
            ImageAppear.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ImageAppear != null)
        {
            ImageAppear.SetActive(false);
        }
    }
}