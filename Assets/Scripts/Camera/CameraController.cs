using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Cinemachine Settings")]
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [Header("Sensitivity Settings")]
    [SerializeField] private float xSensitivity = 1f;
    [SerializeField] private float ySensitivity = 1f;

    [Header("Clamp Angles")]
    [SerializeField] private float minYAngle = -30f;
    [SerializeField] private float maxYAngle = 60f;

    private Vector2 lookInput; // Armazena a entrada do eixo de vis�o
    private Transform cameraTransform; // Refer�ncia � c�mera principal
    private Transform followTarget; // O ponto que a c�mera segue

    private float xAxisValue; // �ngulo da rota��o horizontal
    private float yAxisValue; // �ngulo da rota��o vertical

    private void Awake()
    {
        if (virtualCamera != null)
        {
            // Pega o Transform do objeto seguido pela Cinemachine
            followTarget = virtualCamera.Follow;
            cameraTransform = virtualCamera.transform;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Atualiza o valor da entrada do eixo de vis�o
        lookInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (followTarget == null) return;

        // Atualiza os valores dos eixos com base na sensibilidade
        xAxisValue += lookInput.x * xSensitivity;
        yAxisValue -= lookInput.y * ySensitivity;

        // Clampeia os valores do eixo vertical para limitar a vis�o
        yAxisValue = Mathf.Clamp(yAxisValue, minYAngle, maxYAngle);

        // Aplica a rota��o ao ponto de seguir
        followTarget.rotation = Quaternion.Euler(yAxisValue, xAxisValue, 0);

        // Atualiza a rota��o da c�mera
        cameraTransform.rotation = Quaternion.Euler(yAxisValue, xAxisValue, 0);
    }
}
