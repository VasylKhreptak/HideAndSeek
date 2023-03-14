using System.Collections.Generic;
using CBA.Extensions;
using UnityEngine;

namespace Gameplay.Players
{
    public class PlayerNamesProvider : MonoBehaviour
    {
        [Header("Preferences")]
        [SerializeField] private string[] _names;

        private List<string> _namesList;

        #region MonoBehaviour

        private void Awake()
        {
            Reset();
        }

        #endregion

        public string Get()
        {
            string name = _namesList.Random();
            _namesList.Remove(name);
            return name;
        }

        public void Reset()
        {
            _namesList = new List<string>(_names);
        }
    }
}
