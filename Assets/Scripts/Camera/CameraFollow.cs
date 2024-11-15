using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Referência ao jogador
    public Transform player;

    // Distância da câmera em relação ao jogador
    public Vector3 offset;

    // Velocidade de suavização do movimento da câmera
    public float smoothSpeed = 0.125f;

    // Limites de movimento da câmera
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = 5f;
    public float maxY = 20f;
    public float minZ = -20f;
    public float maxZ = -5f;

    // Variáveis para rotação
    public float rotationSpeed = 5f;
    private float currentRotation = 0f;

    void LateUpdate()
    {
        // Movimento da câmera
        Vector3 desiredPosition = player.position + offset;

        // Limita a posição da câmera com base nos limites definidos
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);
        desiredPosition.z = Mathf.Clamp(desiredPosition.z, minZ, maxZ);

        // Suavização do movimento da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Rotação com o jogador
        float horizontalInput = Input.GetAxis("Mouse X"); // Entrada do mouse para rotação
        currentRotation += horizontalInput * rotationSpeed;
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);

        // Aplica a rotação à câmera
        transform.RotateAround(player.position, Vector3.up, horizontalInput * rotationSpeed);

        // Se você quiser que a câmera sempre olhe para o jogador:
        transform.LookAt(player);
    }
}
