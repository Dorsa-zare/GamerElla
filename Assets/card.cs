using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class card : MonoBehaviour
{
    private Collider2D col;
    private Vector3 startDragPosition;
    private Vector3 dragOffset;
    private int originalSortingOrder;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (col == null)
        {
            Debug.LogError("card: Collider2D is required on the same GameObject.");
        }
        
        if (spriteRenderer != null)
        {
            originalSortingOrder = spriteRenderer.sortingOrder;
        }
    }

    private void OnMouseDown()
    {
        if (col == null) return;

        startDragPosition = transform.position;
        
        // Calculate offset so card doesn't jump to mouse center
        Vector3 mousePos = GetMousePositionInWorldSpace();
        dragOffset = transform.position - mousePos;
        
        // Bring card to front while dragging
        if (spriteRenderer != null)
        {
            originalSortingOrder = spriteRenderer.sortingOrder;
            spriteRenderer.sortingOrder = 100;
        }
    }

    private void OnMouseDrag()
    {
        if (col == null) return;
        transform.position = GetMousePositionInWorldSpace() + dragOffset;
    }

    private void OnMouseUp()
    {
        if (col == null) return;

        // Return to original sorting order
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = originalSortingOrder;
        }

        // Temporarily disable this card's collider to detect what's underneath
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;

        if (hitCollider != null && hitCollider.TryGetComponent(out card otherCard))
        {
            // We hit another card - swap positions!
            Vector3 otherCardPosition = otherCard.transform.position;
            otherCard.transform.position = startDragPosition;
            transform.position = otherCardPosition;
            
            Debug.Log($"{gameObject.name} swapped with {otherCard.gameObject.name}!");
        }
        else
        {
            // No card underneath, return to start position
            transform.position = startDragPosition;
        }
    }

    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0;
        return p;
    }
}