using System.Collections;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [Header("Hole")]
    [SerializeField] private int holeIndex;

    [Header("VFX")]
    [SerializeField] private ParticleSystem holeBurst;

    private bool goalTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (goalTriggered)
            return;

        if (GameManager.Instance.GameFinished)
            return;

        if (!other.CompareTag("Ball"))
            return;

        BallController ball = other.GetComponent<BallController>();

        if (ball == null)
            return;

        if (ball.HasScored)
            return;

        // Ignore if this isn't the current hole
        if (holeIndex != GameManager.Instance.CurrentHole)
            return;

        goalTriggered = true;

        ball.Score();

        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Play hole burst
        if (holeBurst != null)
        {
            holeBurst.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            holeBurst.Play();
        }

        StartCoroutine(GoalRoutine());
    }

    private IEnumerator GoalRoutine()
    {
        yield return new WaitForSeconds(1f);

        GameManager.Instance.HoleCompleted();

        goalTriggered = false;
    }
}