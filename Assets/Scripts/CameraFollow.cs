using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 5f, -7f);
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (player == null) return;

        // Calculate desired camera position based on player rotation
        Vector3 desiredPosition = player.position + player.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Look at player (slightly above to focus on upper body)
        transform.LookAt(player.position + Vector3.up * 3f);
    }
}
