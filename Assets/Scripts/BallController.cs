using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float stopVelocity = 0.05f;
    [SerializeField] private float stopDelay = 0.5f;
    [SerializeField] private float fallHeight = -5f;

    [Header("VFX")]
    [SerializeField] private ParticleSystem moveTrail;

    private Rigidbody rb;

    private bool hasScored = false;
    private bool resetting = false;
    private bool ballStopped = true;

    private float stopTimer = 0f;

    public bool HasScored => hasScored;
    public bool CanShoot => ballStopped;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.Instance.GameFinished)
            return;

        if (resetting)
            return;

        if (hasScored)
            return;

        // Ball fell outside the course
        if (transform.position.y < fallHeight)
        {
            ResetBall();
            return;
        }

        // Detect if the ball has completely stopped
        if (rb.linearVelocity.magnitude <= stopVelocity)
        {
            stopTimer += Time.deltaTime;

            if (stopTimer >= stopDelay)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                ballStopped = true;

                if (moveTrail != null && moveTrail.isPlaying)
                    moveTrail.Stop();
            }
        }
        else
        {
            stopTimer = 0f;
            ballStopped = false;
        }
    }

    public void StartShot()
    {
        ballStopped = false;
        stopTimer = 0f;

        if (moveTrail != null && !moveTrail.isPlaying)
            moveTrail.Play();
    }

    public void Score()
    {
        if (hasScored)
            return;

        hasScored = true;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (moveTrail != null && moveTrail.isPlaying)
            moveTrail.Stop();
    }

    public void ResetState()
    {
        hasScored = false;
        resetting = false;
        ballStopped = true;
        stopTimer = 0f;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (moveTrail != null)
        {
            moveTrail.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    private void ResetBall()
    {
        resetting = true;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if (moveTrail != null)
        {
            moveTrail.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        GameManager.Instance.ResetBall();
    }
}