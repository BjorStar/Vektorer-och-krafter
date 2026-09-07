using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform player;
    public Transform leftAnchor;
    public Transform rightAnchor;

    public LineRenderer bandLeft;
    public LineRenderer bandRight;

    public float maxDragDistance = 1.5f;
    public float launchPower = 10f;

    private bool isDragging = false;
    private Vector2 slingshotCenter;

    void Start()
    {
        slingshotCenter = transform.position;
        ClearBands();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mouseWorld, player.position) < 0.5f)
                isDragging = true;
        }

        if (isDragging)
        {
            DragPlayer();
            UpdateBands();
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            LaunchPlayer();
            ClearBands();
            isDragging = false;
        }
    }

    void DragPlayer()
    {
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorld - slingshotCenter;

        if (direction.magnitude > maxDragDistance)
            direction = direction.normalized * maxDragDistance;

        player.position = slingshotCenter + direction;
    }

    void LaunchPlayer()
    {
        Vector2 direction = slingshotCenter - (Vector2)player.position;
        Vector2 velocity = direction * launchPower;

        player.GetComponent<PlayerPhysics>().Launch(velocity);
    }

    void UpdateBands()
    {
        bandLeft.enabled = true;
        bandRight.enabled = true;

        bandLeft.SetPosition(0, leftAnchor.position);
        bandLeft.SetPosition(1, player.position);

        bandRight.SetPosition(0, rightAnchor.position);
        bandRight.SetPosition(1, player.position);
    }

    void ClearBands()
    {
        bandLeft.enabled = false;
        bandRight.enabled = false;
    }
}
