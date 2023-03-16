using CBA.Events.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Events.Screen
{
    public class OnButtonClick : MonoEvent
    {
        [Header("References")]
        [SerializeField] private Button _button;

        #region MonoBehaviour

        private void OnValidate()
        {
            _button ??= GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Invoke);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Invoke);
        }

        #endregion
    }
}
