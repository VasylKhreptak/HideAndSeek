using Gameplay.HidePlayer;
using TMPro;
using UnityEngine;

namespace UI
{
    public class InspectionProgressText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private AreaInspector _areaInspector;
        [SerializeField] private TMP_Text _tmp;

        [Header("Preferences")]
        [SerializeField] private string _format = "0";

        #region MonoBehaviour

        private void OnValidate()
        {
            _areaInspector ??= FindObjectOfType<AreaInspector>();
            _tmp ??= GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            _areaInspector.onInspectionProgressUpdated += UpdateProgressText;
        }

        private void OnDisable()
        {
            _areaInspector.onInspectionProgressUpdated -= UpdateProgressText;
        }

        #endregion

        private void UpdateProgressText(float progress)
        {
            _tmp.text = (progress * 100).ToString(_format) + "%";
        }
    }
}
