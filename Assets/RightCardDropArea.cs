using UnityEngine;

public class RightCardDropArea : MonoBehaviour, ICardDropArea
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnCardDropped(card card)
    {
        card.transform.position = transform.position; 
        Debug.Log("Card dropped in the left area!");
    }
}
