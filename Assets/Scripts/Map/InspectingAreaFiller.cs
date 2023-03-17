using CBA.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Map
{
    public class InspectingAreaFiller : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InspectionArea[] _inspectingAreas;

        [Header("Preferences")]
        [SerializeField] private int _maxKeys;

        #region MonoBehaviour

        private void OnValidate()
        {
            _inspectingAreas ??= transform.GetComponentsInChildren<InspectionArea>();
        }

        private void Awake()
        {
            Fill();
        }

        #endregion

        private void Fill()
        {
            for (int i = 0; i < _maxKeys; i++)
            {
                _inspectingAreas.Random().hasKey = true;
            }
        }
    }
}
