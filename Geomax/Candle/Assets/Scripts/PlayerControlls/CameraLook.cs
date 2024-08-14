using Zenject;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;

    [Space]

    [SerializeField] private CharacterControllerSettingsScriptableObject _characterSettings;
    [SerializeField][Range(0, 90)] private float _downLookAngle = 60;
    [SerializeField][Range(0, -90)] private float _topLookAngle = -90;

    [Inject] private ILookImputSystem _input;

    private Transform _cachedTransform;
    private float _xRotationCoeficient;

    private void Start()
    {
        _cachedTransform = transform;
        _xRotationCoeficient = 0;
    }

    private void Update()
    {
        Vector2 inputVector = _input.LookInputVector;

        _xRotationCoeficient += inputVector.y * _characterSettings.CameraSensitivity * Time.deltaTime;
        _xRotationCoeficient = Mathf.Clamp(_xRotationCoeficient, _topLookAngle, _downLookAngle);

        _cachedTransform.localRotation = Quaternion.Euler(_xRotationCoeficient, 0f, 0f);
        _playerBody.Rotate(Vector3.up * inputVector.x * _characterSettings.CameraSensitivity * Time.deltaTime);        
    }
}