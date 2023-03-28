using System;
using Data;
using Skins;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Shop.Buttons
{
    public abstract class SelectButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Button _button;
        [SerializeField] private SkinChanger _skinChanger;

        [Header("Preferences")]
        [SerializeField] private Skin _skin;

        private IDisposable _disposable;

        protected PlayerDataProvider _playerDataProvider;

        [Inject]
        private void Construct(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;
        }

        #region Monobehaviour

        private void OnValidate()
        {
            _button ??= GetComponent<Button>();
            _skinChanger ??= FindObjectOfType<SkinChanger>();
        }

        private void Awake()
        {
            _disposable = _button.OnClickAsObservable().Subscribe(_ => Select());
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }

        #endregion

        private void Select()
        {
            _skinChanger.SetSkin(_skin);
            OnSelected(_skin);
        }

        protected abstract void OnSelected(Skin skin);
    }
}
