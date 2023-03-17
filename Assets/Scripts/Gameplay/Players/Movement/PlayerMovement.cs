using UnityEngine;
using Zenject;

namespace Gameplay.Players.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;

        [Header("Preferences")]
        [SerializeField] private float _force = 5f;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private ForceMode _forceMode = ForceMode.Force;

        private Joystick _joystick;

        public float Speed => _maxSpeed;

        [Inject]
        private void Construct(Joystick joystick)
        {
            _joystick = joystick;
        }

        public void SetSpeed(float speed)
        {
            if (speed < 0f)
            {
                speed = 0;
            }

            _maxSpeed = speed;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _transform ??= GetComponent<Transform>();
            _rigidbody ??= GetComponent<Rigidbody>();
        }

        private void Update()
        {
            float horizontal = _joystick.Horizontal;
            float vertical = _joystick.Vertical;

            Vector3 direction = new Vector3(horizontal, 0f, vertical);
            direction = Vector3.ClampMagnitude(direction, 1f);
            direction = _transform.rotation * direction;

            _rigidbody.AddForce(direction * _force, _forceMode);
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
        }

        #endregion
    }
}
