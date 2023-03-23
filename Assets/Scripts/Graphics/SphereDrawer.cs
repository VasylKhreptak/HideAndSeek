using UnityEngine;

namespace Graphics
{
    public class SphereDrawer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _transform;

        [Header("Preferences")]
        [SerializeField] private float _radius;
        [SerializeField] private Color _color = CBA.Extensions.Color.WithAlpha(Color.red, 0.4f);

        #region MonoBehaviour

        private void OnValidate()
        {
            _transform ??= GetComponent<Transform>();
        }

        #endregion

        protected void DrawSphere()
        {
            if (_transform == null) return;

            Gizmos.color = _color;
            Gizmos.DrawSphere(_transform.position, _radius);
        }
    }
}
