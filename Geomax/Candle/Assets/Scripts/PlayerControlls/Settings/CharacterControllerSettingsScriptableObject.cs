using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSettings", menuName = "Game design/CharacterSettings")]
public class CharacterControllerSettingsScriptableObject : ScriptableObject
{
    [SerializeField][Min(0.1f)] private float _cameraSensitivity = 100;
    [SerializeField][Min(0.1f)] private float _moveSpeed = 10;

    public float CameraSensitivity => _cameraSensitivity;
    public float MoveSpeed => _moveSpeed;
}