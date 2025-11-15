using UnityEngine;

public class card : MonoBehaviour
{
    private Collider2D col;

    private Vector3 startDragPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider2D>();
    }
    private void OnMouseDown()
    {
        startDragPosition = transform.position;
        transform.position = GetMousePositionInWorldSpace();
    }
    private void OnMouseDrag()
    {
        transform.position = GetMousePositionInWorldSpace();
    }
    private void OnMouseUp()
    {
        
    }
    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0;
        return p;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
