using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Trajectory : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LineRenderer lineRenderer;

    [Header("Aim Line")]
    [SerializeField] private int segments = 25;
    [SerializeField] private float lineLength = 8f;

    private void Awake()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 0;
    }

    public void ShowTrajectory(Vector3 startPosition, Vector3 velocity)
    {
        lineRenderer.positionCount = segments;

        Vector3 direction = velocity.normalized;

        float length = Mathf.Clamp(
            velocity.magnitude,
            0.5f,
            lineLength);

        for (int i = 0; i < segments; i++)
        {
            float t = (float)i / (segments - 1);

            Vector3 point =
                startPosition +
                direction * length * t;

            // Keep the line slightly above the ground
            point.y = startPosition.y + 0.05f;

            lineRenderer.SetPosition(i, point);
        }
    }

    public void HideTrajectory()
    {
        lineRenderer.positionCount = 0;
    }
}