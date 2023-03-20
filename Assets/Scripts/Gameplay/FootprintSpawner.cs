using System;
using System.Collections;
using CBA.Adapters.Color.Core;
using Plugins.ObjectPooler;
using Providers.Core;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class FootprintSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3Provider _speedProvider;

        [Header("Preferences")]
        [SerializeField] private Pool _footprint;
        [SerializeField] private Color _color;
        [SerializeField] private float _spawnInterval = 0.5f;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _speedCheckInterval = 0.3f;

        private Coroutine _spawnCoroutine;

        private IDisposable _speedCheckDisposable;

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
            _speedProvider ??= GetComponent<Vector3Provider>();
        }

        private void OnEnable()
        {
            _speedCheckDisposable = Observable.Interval(TimeSpan.FromSeconds(_speedCheckInterval)).Subscribe(_ =>
            {
                Vector2 horizontalVelocity = new Vector2(_speedProvider.vector.x, _speedProvider.vector.z);

                if (horizontalVelocity.magnitude > _minSpeed)
                {
                    StartSpawning();
                }
                else
                {
                    StopSpawning();
                }
            });
        }

        private void OnDisable()
        {
            _speedCheckDisposable.Dispose();
            StopSpawning();
        }

        #endregion


        private void StartSpawning()
        {
            if (_spawnCoroutine == null)
            {
                _spawnCoroutine = StartCoroutine(SpawnRoutine());
            }
        }

        private void StopSpawning()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
                _spawnCoroutine = null;
            }
        }

        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                Spawn();

                yield return new WaitForSeconds(_spawnInterval);
            }
        }

        private void Spawn()
        {
            GameObject footprint = _objectPooler.Spawn(_footprint, _transform.position);
            footprint.transform.forward = _transform.forward;

            if (footprint.TryGetComponent(out ColorAdapter colorAdapter))
            {
                colorAdapter.color = _color;
            }
        }
    }
}
