using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingLogic : MonoBehaviour
{
    [Header("Ending Scene Indices")]
    public int socialEndingScene = 5;    // Scene index for social ending
    public int sexualEndingScene = 7;    // Scene index for sexual ending
    public int conversationEndingScene = 6; // Scene index for conversation ending

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        
        if (gameManager == null)
        {
            Debug.LogError("EndingManager: GameManager instance not found!");
            return;
        }

        // Automatically determine and load the appropriate ending
        DetermineEnding();
    }

    // Optional: Call this after showing the ending if you want to reset for replay
    public void ResetAfterEnding()
    {
        if (gameManager != null)
        {
            gameManager.ResetScores();
            Debug.Log("Scores reset after ending.");
        }
    }

    void DetermineEnding()
    {
        int so = gameManager.so;
        int sx = gameManager.sx;
        int sp = gameManager.sp;

        Debug.Log($"Final Scores - Social: {so}, Sexual: {sx}, Conversation: {sp}");

        // Find the maximum score
        int maxScore = Mathf.Max(so, sx, sp);

        // Count how many categories have the max score (for tie detection)
        int tieCount = 0;
        if (so == maxScore) tieCount++;
        if (sx == maxScore) tieCount++;
        if (sp == maxScore) tieCount++;

        // If there's a tie, randomly pick one of the tied options
        if (tieCount > 1)
        {
            Debug.Log("Tie detected! Choosing random ending from tied options.");
            LoadRandomTiedEnding(so, sx, sp, maxScore);
        }
        else
        {
            // No tie - load the clear winner
            if (so == maxScore)
            {
                Debug.Log("Social ending wins!");
                SceneManager.LoadScene(socialEndingScene);
            }
            else if (sx == maxScore)
            {
                Debug.Log("Sexual ending wins!");
                SceneManager.LoadScene(sexualEndingScene);
            }
            else if (sp == maxScore)
            {
                Debug.Log("Conversation ending wins!");
                SceneManager.LoadScene(conversationEndingScene);
            }
        }
    }

    void LoadRandomTiedEnding(int so, int sx, int sp, int maxScore)
    {
        // Create a list of tied endings
        System.Collections.Generic.List<int> tiedEndings = new System.Collections.Generic.List<int>();

        if (so == maxScore) tiedEndings.Add(socialEndingScene);
        if (sx == maxScore) tiedEndings.Add(sexualEndingScene);
        if (sp == maxScore) tiedEndings.Add(conversationEndingScene);

        // Randomly pick one from the tied endings
        int randomIndex = Random.Range(0, tiedEndings.Count);
        int chosenScene = tiedEndings[randomIndex];

        Debug.Log($"Randomly chose scene: {chosenScene}");
        SceneManager.LoadScene(chosenScene);
    }
}