using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class KeySign : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Image _image;

        public void SetState(bool state)
        {
            _image.color = state ? Color.white : Color.black;
        }
    }
}
