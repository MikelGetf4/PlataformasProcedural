using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public float verticalOffset = 2f;
    public float horizontalOffset = 2f;
    public float fixedYPosition;

    void Start()
    {
        // Fijamos la posici�n Y inicial de la c�mara seg�n la posici�n del jugador al comienzo
        fixedYPosition = transform.position.y;
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = new Vector3(
            player.position.x + horizontalOffset,
            fixedYPosition,  // Usamos la posici�n fija de Y
            transform.position.z
        );

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}