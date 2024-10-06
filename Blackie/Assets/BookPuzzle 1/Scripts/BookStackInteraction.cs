using UnityEngine;

public class BookStackInteraction : MonoBehaviour
{
    private bool isInteractable = false;
    private bool isDragging = false;
    private Vector3 offset;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isInteractable = true;
            }
        }

        if (isInteractable && Input.GetMouseButtonDown(0))
        {
            StartDragging();
        }

        if (isDragging)
        {
            Drag();

            if (Input.GetMouseButtonUp(0))
            {
                StopDragging();
            }
        }
    }

    private void StartDragging()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
        isDragging = true;
    }

    private void Drag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    private void StopDragging()
    {
        isDragging = false;
        isInteractable = false;
    }
}
