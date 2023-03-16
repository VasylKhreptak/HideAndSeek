using UnityEngine;

namespace Management
{
    public class LookAtCamera : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _transform;

        private Transform _cameraTransform;

        #region MonoBehaviour

        private void OnValidate()
        {
            _transform ??= GetComponent<Transform>();
        }

        private void Awake()
        {
            _cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            Look();
        }

        #endregion

        private void Look()
        {
            _transform.rotation = Quaternion.LookRotation(_cameraTransform.position - _transform.position);
        }
    }
}
