using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Timer
{
    public abstract class TimerPartText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] protected TMP_Text _tmp;

        private Gameplay.Timer _timer;

        [Inject]
        private void Construct(Gameplay.Timer timer)
        {
            _timer = timer;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _tmp ??= GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            _timer.onValueChanged += UpdateText;
            _timer.onReset += ResetText;
        }

        private void OnDisable()
        {
            _timer.onValueChanged -= UpdateText;
            _timer.onReset -= ResetText;
        }

        #endregion

        protected abstract void UpdateText(int seconds);

        private void ResetText()
        {
            _tmp.text = "00";
        }
    }
}
