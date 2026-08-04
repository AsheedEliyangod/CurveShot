using UnityEngine;

public class VFXFollow : MonoBehaviour
{
    [SerializeField] private Transform ball;

    [SerializeField] private Vector3 offset = new Vector3(0f, -0.03f, 0f);

    private void LateUpdate()
    {
        transform.position = ball.position + offset;

        // Keep a fixed rotation so the smoke doesn't spin
        transform.rotation = Quaternion.identity;
    }
}