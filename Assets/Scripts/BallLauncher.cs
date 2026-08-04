using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Trajectory trajectory;

    [Header("Shot Settings")]
    [SerializeField] private float maxPower = 12f;
    [SerializeField] private float maxDragDistance = 3f;

    private BallController ballController;

    private bool isDragging;

    private Plane dragPlane;
    private Vector3 dragStartWorld;
    private Vector3 shotVelocity;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        ballController = ballRb.GetComponent<BallController>();
    }

    private void Update()
    {
        if (GameManager.Instance.GameFinished)
            return;

        if (!ballController.CanShoot)
            return;

        // Keep the drag plane at the current ball position
        dragPlane = new Plane(Vector3.up, ballRb.position);

        HandleInput();
    }

    private void HandleInput()
    {
        // ----------------------------------------------------
        // Start dragging ANYWHERE on the screen
        // ----------------------------------------------------
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStartWorld = GetMouseWorldPosition();
        }

        // ----------------------------------------------------
        // Aim while dragging
        // ----------------------------------------------------
        if (isDragging)
        {
            Vector3 currentWorld = GetMouseWorldPosition();

            Vector3 drag = dragStartWorld - currentWorld;
            drag.y = 0f;

            if (drag.magnitude > maxDragDistance)
                drag = drag.normalized * maxDragDistance;

            float power =
                (drag.magnitude / maxDragDistance) * maxPower;

            shotVelocity = drag.normalized * power;

            trajectory.ShowTrajectory(
                ballRb.position,
                shotVelocity);
        }

        // ----------------------------------------------------
        // Shoot
        // ----------------------------------------------------
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;

            trajectory.HideTrajectory();

            Launch();
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (dragPlane.Raycast(ray, out float enter))
            return ray.GetPoint(enter);

        return ballRb.position;
    }

    private void Launch()
    {
        if (shotVelocity.sqrMagnitude < 0.01f)
            return;

        ballController.StartShot();

        ballRb.linearVelocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

        ballRb.AddForce(
            shotVelocity,
            ForceMode.Impulse);

        GameManager.Instance.UseShot();
    }

    public void SetCurrentBall(Rigidbody rb)
    {
        ballRb = rb;
        ballController = rb.GetComponent<BallController>();

        ballRb.linearVelocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
    }
}