using Providers.Core;
using UnityEngine;

namespace Graphics.Animations
{
    public class MovementAnimation : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator _animator;
        [SerializeField] private Vector3Provider _velocityProvider;

        [Header("Preferences")]
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;

        [Header("Animator Preferences")]
        [SerializeField] private string _speedParameterName = "Speed";

        #region MonoBehaviour

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
            _velocityProvider ??= GetComponent<Vector3Provider>();
        }

        #endregion

        private void FixedUpdate()
        {
            float speed = _velocityProvider.vector.magnitude;
            float normalizedSpeed = Mathf.InverseLerp(_minSpeed, _maxSpeed, speed);
            _animator.SetFloat(_speedParameterName, normalizedSpeed);
        }
    }
}
