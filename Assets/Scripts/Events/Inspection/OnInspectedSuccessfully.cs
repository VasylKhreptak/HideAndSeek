using CBA.Events.Core;
using Gameplay.HidePlayer;
using UnityEngine;

namespace Events.Inspection
{
    public class OnInspectedSuccessfully : MonoEvent
    {
        [Header("References")]
        [SerializeField] private AreaInspector _areaInspector;

        #region MonoBehaviour

        private void OnValidate()
        {
            _areaInspector ??= FindObjectOfType<AreaInspector>();
        }

        private void OnEnable()
        {
            _areaInspector.onInspectedSuccessfully += Invoke;
        }

        private void OnDisable()
        {
            _areaInspector.onInspectedSuccessfully -= Invoke;
        }

        #endregion
    }
}
