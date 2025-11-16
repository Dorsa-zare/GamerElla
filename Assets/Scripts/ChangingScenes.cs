using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenes : MonoBehaviour
{
    private GameManager manager;
    public int sceneIndex = 2;
    [SerializeField] private string option;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameManager.Instance;
        if (manager == null)
        {
            Debug.LogError("Hover: GameManager instance not found.");
        }
    }

    // Update is called once per frame
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