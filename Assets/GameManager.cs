using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int so;
    public int sx;
    public int sp;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep the GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(string option, int score)
    {
        switch (option)
        {
            case "sp": sp += score; break;
            case "sx": sx += score; break;
            case "so": so += score; break;
        }
    }
}
