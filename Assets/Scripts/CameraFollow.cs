using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public float verticalOffset = 2f;
    public float horizontalOffset = 2f;

    // Variable para fijar la posici�n en Y de la c�mara
    public float fixedYPosition;

    void Start()
    {
        // Fijamos la posici�n Y inicial de la c�mara seg�n la posici�n del jugador al comienzo
        fixedYPosition = transform.position.y;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // En Cliff Jump, la c�mara sigue solo en la direcci�n horizontal
        Vector3 targetPosition = new Vector3(
            player.position.x + horizontalOffset,
            fixedYPosition,  // Usamos la posici�n fija de Y
            transform.position.z
        );

        // Lerp para suavizar el movimiento
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}