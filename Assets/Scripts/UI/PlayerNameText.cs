using Gameplay.Players;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerNameText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text _tmp;
        [SerializeField] private PlayerNamesProvider _namesProvider;

        #region MonoBehaviour

        private void OnValidate()
        {
            _tmp ??= GetComponent<TMP_Text>();
        }

        private void Start()
        {
            SetNames(_namesProvider.Get());
        }

        #endregion

        private void SetNames(string name)
        {
            _tmp.text = name;
        }
    }
}
