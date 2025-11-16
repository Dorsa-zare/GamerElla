using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ClickCard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (sprite == null) Debug.LogWarning("ClickCard: no Renderer found (add a Renderer or change the code).");
    }
    void OnMouseDown()
    {
        DoSomething();
    }

    void DoSomething()
    {
        Debug.Log("Card clicked!");
        if (sprite != null)
        {
            // example action: change color on click
            sprite.color = Random.ColorHSV();
        }
    }
   
}
