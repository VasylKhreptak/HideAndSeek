using Data;
using UniRx;
using UnityEngine;
using Zenject;

namespace Actions
{
    public class ResetTransformOnSkinChanged : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _transform;

        private PlayerDataProvider _playerDataProvider;

        private CompositeDisposable _disposable = new CompositeDisposable();

        [Inject]
        private void Construct(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _transform ??= GetComponent<Transform>();
        }

        private void Start()
        {
            _playerDataProvider.Data.skinData.currentSeekSkin.Subscribe(_ => ResetPositionAndRotation()).AddTo(_disposable);
            _playerDataProvider.Data.skinData.currentHideSkin.Subscribe(_ => ResetPositionAndRotation()).AddTo(_disposable);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }

        #endregion

        private void ResetPositionAndRotation()
        {
            _transform.localPosition = Vector3.zero;
            _transform.localRotation = Quaternion.identity;
        }
    }
}
