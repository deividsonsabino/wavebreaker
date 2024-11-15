using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Refer�ncia ao jogador
    public Transform player;

    // Dist�ncia da c�mera em rela��o ao jogador
    public Vector3 offset;

    // Velocidade de suaviza��o do movimento da c�mera
    public float smoothSpeed = 0.125f;

    // Limites de movimento da c�mera
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = 5f;
    public float maxY = 20f;
    public float minZ = -20f;
    public float maxZ = -5f;

    // Vari�veis para rota��o
    public float rotationSpeed = 5f;
    private float currentRotation = 0f;

    void LateUpdate()
    {
        // Movimento da c�mera
        Vector3 desiredPosition = player.position + offset;

        // Limita a posi��o da c�mera com base nos limites definidos
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        desiredPosition.z = Mathf.Clamp(desiredPosition.z, minZ, maxZ);

        // Suaviza��o do movimento da c�mera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Rota��o com o jogador
        float horizontalInput = Input.GetAxis("Mouse X"); // Entrada do mouse para rota��o
        currentRotation += horizontalInput * rotationSpeed;
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);

        // Aplica a rota��o � c�mera
        transform.RotateAround(player.position, Vector3.up, horizontalInput * rotationSpeed);

        // Se voc� quiser que a c�mera sempre olhe para o jogador:
        transform.LookAt(player);
    }
}
