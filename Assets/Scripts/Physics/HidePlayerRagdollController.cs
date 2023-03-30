using System;
using System.Linq;
using Data;
using Physics;
using Skins;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class HidePlayerRagdollController : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private bool _initialState;
    [FormerlySerializedAs("_kvps")]
    [SerializeField] private KVP[] _KVPs;

    private RagdollControl _activeRagdollControl;

    private PlayerDataProvider _playerDataProvider;

    private IDisposable _disposable;

    [Inject]
    private void Construct(PlayerDataProvider playerDataProvider)
    {
        _playerDataProvider = playerDataProvider;
    }

    #region MonoBehaviour

    private void Start()
    {
        UpdateCurrentRagdollControl(_playerDataProvider.Data.skinData.currentHideSkin.Value);
        SetActive(_initialState);
        _disposable = _playerDataProvider.Data.skinData.currentHideSkin.Subscribe(UpdateCurrentRagdollControl);
    }

    private void OnDestroy()
    {
        _disposable.Dispose();
    }

    #endregion

    public void SetActive(bool state)
    {
        _activeRagdollControl.SetActive(state);
    }

    public Rigidbody[] GetRigidbodies()
    {
        return _activeRagdollControl.GetRigidbodies();
    }

    private void UpdateCurrentRagdollControl(Skin skin)
    {
        _activeRagdollControl = _KVPs.First(x => x.skin == skin).ragdollControl;
    }

    [Serializable]
    private class KVP
    {
        public RagdollControl ragdollControl;
        public Skin skin;
    }
}
