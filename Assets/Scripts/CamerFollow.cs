using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    public Transform player; // Drag the player here in Inspector
    public Vector3 offset = new Vector3(0, 5, -10); // Adjust the position
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (player == null) return; // Ensure player is assigned

        // Calculate smooth position
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Make camera always look at the player (optional)
        transform.LookAt(player);
    }
}
