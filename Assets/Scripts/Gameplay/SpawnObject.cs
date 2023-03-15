using Plugins.ObjectPooler;
using UnityEngine;
using Zenject;
using Action = CBA.Actions.Core.Action;
using Color = CBA.Extensions.Color;

namespace Gameplay
{
    public class SpawnObject : Action
    {
        [Header("References")]
        [SerializeField] private Transform _transform;

        [Header("Preferences")]
        [SerializeField] private Pool _pool;
        [SerializeField] private float _range = 5f;
        [SerializeField] private bool _randomizeYRotation = true;

        private ObjectPooler _objectPooler;

        [Inject]
        private void Construct(ObjectPooler objectPooler)
        {
            _objectPooler = objectPooler;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _transform ??= GetComponent<Transform>();
        }

        #endregion
        
        public override void Do()
        {
            Vector3 position = GetPosition();
            Quaternion rotation = GetRotation();
            _objectPooler.Spawn(_pool, position, rotation);
        }

        private Vector3 GetPosition()
        {
            Vector2 inside = Random.insideUnitCircle * _range;
            Vector3 direction = new Vector3(inside.x, 0f, inside.y);
            return _transform.position + direction;
        }

        private Quaternion GetRotation()
        {
            return _randomizeYRotation ? Quaternion.Euler(0f, Random.Range(0f, 360f), 0f) : Quaternion.identity;
        }

        private void OnDrawGizmos()
        {
            if (_transform == null) return;

            Gizmos.color = Color.WithAlpha(UnityEngine.Color.red, 0.4f);
            Gizmos.DrawSphere(_transform.position, _range);
        }
    }
}
