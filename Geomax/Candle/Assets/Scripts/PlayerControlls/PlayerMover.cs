using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CharacterControllerSettingsScriptableObject _settings;

    [Inject] private IMoveInputSystem _input;

    private CharacterController _controller;
    private Transform _cachedTranform;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _cachedTranform = transform;
    }

    private void Update()
    {
        Vector2 inputVector = _input.InputVector;

        Vector3 nextPosition = _cachedTranform.right * inputVector.x + _cachedTranform.forward * inputVector.y;

        _controller.Move(nextPosition * _settings.MoveSpeed * Time.deltaTime);
    }
}