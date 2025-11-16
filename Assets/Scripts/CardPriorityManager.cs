// ===== NEW SCRIPT: CardPriorityManager.cs =====
// Attach this to a GameObject in the scene

using UnityEngine;
using UnityEngine.SceneManagement;

public class CardPriorityManager : MonoBehaviour
{
    [Header("Drop Zones (Priority Positions)")]
    [SerializeField] private Transform position1; // Most important - 3 points
    [SerializeField] private Transform position2; // Medium important - 2 points
    [SerializeField] private Transform position3; // Least important - 1 point
    
    [Header("Scene Settings")]
    [SerializeField] private int soWinSceneIndex = 3;
    [SerializeField] private int spWinSceneIndex = 4;
    [SerializeField] private int sxWinSceneIndex = 5;
    
    [Header("Detection Settings")]
    [SerializeField] private float detectionRadius = 1f;
    
    private GameManager manager;

    void Start()
    {
        manager = GameManager.Instance;
        if (manager == null)
        {
            Debug.LogError("CardPriorityManager: GameManager instance not found.");
        }
    }

    // Call this from a "Confirm/Submit" button
    public void CalculateAndProceed()
    {
        if (manager == null)
        {
            Debug.LogError("GameManager not available!");
            return;
        }

        // Find which cards are in which positions
        card cardAt1 = FindCardNearPosition(position1.position);
        card cardAt2 = FindCardNearPosition(position2.position);
        card cardAt3 = FindCardNearPosition(position3.position);

        if (cardAt1 == null || cardAt2 == null || cardAt3 == null)
        {
            Debug.LogWarning("Not all positions are filled! Please place all 3 cards.");
            return;
        }

        // Get what type each card is
        string typeAt1 = cardAt1.GetCardType(); // This card gets 3 points
        string typeAt2 = cardAt2.GetCardType(); // This card gets 2 points
        string typeAt3 = cardAt3.GetCardType(); // This card gets 1 point

        // Add points based on position
        // Position 1 (most important) = 3 points
        manager.AddPoints(typeAt1, cardAt1.GetBasePoints() * 3);
        
        // Position 2 (medium) = 2 points
        manager.AddPoints(typeAt2, cardAt2.GetBasePoints() * 2);
        
        // Position 3 (least important) = 1 point
        manager.AddPoints(typeAt3, cardAt3.GetBasePoints() * 1);
        
        Debug.Log($"Points added: {typeAt1}=3pts, {typeAt2}=2pts, {typeAt3}=1pt");
        
        // Determine winner and load appropriate scene
        DetermineWinnerAndLoadScene();
    }

    private card FindCardNearPosition(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, detectionRadius);
        
        foreach (Collider2D col in colliders)
        {
            if (col.TryGetComponent(out card foundCard))
            {
                return foundCard;
            }
        }
        
        return null;
    }

    private void DetermineWinnerAndLoadScene()
    {
        int soPoints = manager.GetPoints("so");
        int spPoints = manager.GetPoints("sp");
        int sxPoints = manager.GetPoints("sx");
        
        Debug.Log($"Final Scores - SO: {soPoints}, SP: {spPoints}, SX: {sxPoints}");
        
        // Load scene based on which type has the most points
        if (soPoints > spPoints && soPoints > sxPoints)
        {
            Debug.Log("SO wins!");
            SceneManager.LoadSceneAsync(soWinSceneIndex);
        }
        else if (spPoints > soPoints && spPoints > sxPoints)
        {
            Debug.Log("SP wins!");
            SceneManager.LoadSceneAsync(spWinSceneIndex);
        }
        else if (sxPoints > soPoints && sxPoints > spPoints)
        {
            Debug.Log("SX wins!");
            SceneManager.LoadSceneAsync(sxWinSceneIndex);
        }
        else
        {
            // Handle tie - load highest priority or default
            Debug.Log("Tie! Loading default scene.");
            SceneManager.LoadSceneAsync(soWinSceneIndex);
        }
    }
    
    private void OnDrawGizmos()
    {
        if (position1 != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(position1.position, detectionRadius);
        }
        if (position2 != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(position2.position, detectionRadius);
        }
        if (position3 != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(position3.position, detectionRadius);
        }
    }
}