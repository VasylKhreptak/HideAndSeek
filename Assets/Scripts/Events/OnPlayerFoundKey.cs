using System;
using CBA.Events.Core;
using Gameplay.HidePlayer;
using UniRx;
using UnityEngine;

namespace Events
{
    public class OnPlayerFoundKey : MonoEvent
    {
        [Header("References")]
        [SerializeField] private KeyHolder _keyHolder;

        private IDisposable _disposable;

        #region MonoBehaviour

        private void OnValidate()
        {
            _keyHolder ??= FindObjectOfType<KeyHolder>();
        }

        private void OnEnable()
        {
            _disposable = _keyHolder.HasKeyProperty.Subscribe(hasKey =>
            {
                if (hasKey)
                {
                    Invoke();
                }
            });
        }

        private void OnDisable()
        {
            _disposable.Dispose();
        }

        #endregion
    }
}
