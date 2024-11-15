using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Refer�ncia ao jogador
    public Transform player;

    // Dist�ncia da c�mera em rela��o ao jogador
    public Vector3 offset;

    // Velocidade de suaviza��o do movimento da c�mera
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Calcula a posi��o desejada com base na posi��o do jogador e no offset
        Vector3 desiredPosition = player.position + offset;

        // Move a c�mera suavemente em dire��o � posi��o desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Define a nova posi��o da c�mera
        transform.position = smoothedPosition;

        // Se voc� quiser que a c�mera sempre olhe para o jogador:
        transform.LookAt(player);
    }
}
