using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private CharacterController _characterController;

    [Header("Preferences")]
    [SerializeField] private float _speed = 5f;

    private Joystick _joystick;

    [Inject]
    private void Construct(Joystick joystick)
    {
        _joystick = joystick;
    }

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _characterController ??= GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = _joystick.Horizontal;
        float vertical = _joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        direction = Vector3.ClampMagnitude(direction, 1f);
        direction = _transform.rotation * direction;
        Vector3 motion = direction * _speed;

        _characterController.Move(motion * Time.deltaTime);
    }

    #endregion
}
