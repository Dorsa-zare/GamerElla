using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int so; // Social
    public int sx; // Sexual
    public int sp; // Conversation

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void Start()
    {
        // Reset scores when the game starts
        ResetScores();
        Debug.Log("Game started - scores reset to 0");
    }

    public void AddPoints(string option, int score)
    {
        switch (option)
        {
            case "sp": sp += score; break;
            case "sx": sx += score; break;
            case "so": so += score; break;
            default:
                Debug.LogWarning($"Invalid option: {option}");
                break;
        }
        
        // Optional: Log the current scores for debugging
        Debug.Log($"Points added to {option}. Current scores - SO: {so}, SX: {sx}, SP: {sp}");
    }

    // Method to reset scores
    public void ResetScores()
    {
        so = 0;
        sx = 0;
        sp = 0;
        Debug.Log("Scores reset!");
    }
    public int GetPoints(string type)
{
    switch (type)
    {
        case "so": return so;
        case "sp": return sp;
        case "sx": return sx;
        default: return 0;
    }
}
}