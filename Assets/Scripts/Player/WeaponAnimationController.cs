using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAnimationController : MonoBehaviour
{
    private Animator _animator;
    private StarterAssetsInputs _input;

#if ENABLE_INPUT_SYSTEM
    private PlayerInput _playerInput;
#endif

    private int _animIDIsHoldingGun;
    private int _animIDIShoot;

    private bool _hasAnimator;
    private bool _isShooting;

    private void Start()
    {
        _hasAnimator = TryGetComponent(out _animator);
        _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM
        _playerInput = GetComponent<PlayerInput>();
#else
        Debug.LogError("Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif

        AssignAnimationIDs();
    }

    private void Update()
    {
        _hasAnimator = TryGetComponent(out _animator);
        HoldGun();
        Shoot();
    }

    private void HoldGun()
    {
        if (_hasAnimator)
        {
            // Verifica se o jogador está segurando a arma
            if (_input.isHoldingGun)
            {
                // Ativa a animação de segurar a arma
                _animator.SetLayerWeight(1, 1f);
                _animator.SetBool(_animIDIsHoldingGun, true);
            }
            else
            {
                // Desativa a animação de segurar a arma quando o jogador soltar a arma
                _animator.SetLayerWeight(1, 0f); // Corrigido: muda o peso da camada 1
                _animator.SetBool(_animIDIsHoldingGun, false);
            }
        }
    }

    private void Shoot()
    {
        // Verifica se o botão de tiro foi pressionado e se o personagem não está disparando
        if (_input.shoot && !_isShooting)
        {
            if (_hasAnimator)
                _isShooting = true;
                _animator.SetTrigger(_animIDIShoot); // Aciona a animação de disparo
                Invoke("ResetShootState", 0.02f); // Ajuste o tempo do cooldown do disparo, conforme necessário
        }
    }

    private void ResetShootState()
    {
        _isShooting = false; // Permite que o personagem atire novamente
        _animator.SetTrigger(_animIDIShoot);
    }

    private void AssignAnimationIDs()
    {
        // Usa o método StringToHash para otimizar a busca por parâmetros de animação
        _animIDIsHoldingGun = Animator.StringToHash("isHoldingGun");
        _animIDIShoot = Animator.StringToHash("Shoot");
    }
}
