using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;

    [Header("References")]
    [SerializeField] private Transform ball;
    [SerializeField] private Rigidbody ballRb;

    [Header("Follow")]
    [SerializeField] private float followSpeed = 8f;

    [SerializeField]
    private Vector3 normalOffset = new Vector3(-8f, 5f, 0f);

    [SerializeField]
    private Vector3 movingOffset = new Vector3(-11f, 6f, 0f);

    [Header("Look")]
    [SerializeField] private float rotationSpeed = 6f;
    [SerializeField] private float lookAheadDistance = 3f;

    [Header("Movement Detection")]
    [SerializeField] private float movingThreshold = 0.2f;

    private Vector3 currentOffset;

    private void Awake()
    {
        Instance = this;
        currentOffset = normalOffset;
    }

    private void LateUpdate()
    {
        if (ball == null)
            return;

        bool moving = false;

        if (ballRb != null)
            moving = ballRb.linearVelocity.magnitude > movingThreshold;

        //---------------------------------
        // Smooth Zoom
        //---------------------------------

        Vector3 targetOffset =
            moving ? movingOffset : normalOffset;

        currentOffset = Vector3.Lerp(
            currentOffset,
            targetOffset,
            3f * Time.deltaTime);

        //---------------------------------
        // Follow
        //---------------------------------

        Vector3 desiredPosition =
            ball.position + currentOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime);

        //---------------------------------
        // Look Ahead
        //---------------------------------

        Vector3 lookPoint = ball.position;

        if (moving)
        {
            lookPoint +=
                ballRb.linearVelocity.normalized *
                lookAheadDistance;
        }
        else
        {
            lookPoint += Vector3.right * 2f;
        }

        lookPoint.y = ball.position.y + 0.3f;

        Quaternion targetRotation =
            Quaternion.LookRotation(
                lookPoint - transform.position,
                Vector3.up);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }

    public void SetBall(Transform newBall)
    {
        ball = newBall;

        if (newBall != null)
            ballRb = newBall.GetComponent<Rigidbody>();
    }

    public void SnapToBall()
    {
        if (ball == null)
            return;

        transform.position =
            ball.position + normalOffset;
    }
}