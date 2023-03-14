using CBA.Actions.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Actions
{
    public class SetImage : Action
    {
        [Header("References")]
        [SerializeField] private Image _image;

        [Header("Preferences")]
        [SerializeField] private Sprite _sprite;

        public override void Do()
        {
            _image.sprite = _sprite;
        }
    }
}
