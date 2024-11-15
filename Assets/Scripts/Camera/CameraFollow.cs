using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Referência ao jogador
    public Transform player;

    // Distância da câmera em relação ao jogador
    public Vector3 offset;

    // Velocidade de suavização do movimento da câmera
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Calcula a posição desejada com base na posição do jogador e no offset
        Vector3 desiredPosition = player.position + offset;

        // Move a câmera suavemente em direção à posição desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Define a nova posição da câmera
        transform.position = smoothedPosition;

        // Se você quiser que a câmera sempre olhe para o jogador:
        transform.LookAt(player);
    }
}
