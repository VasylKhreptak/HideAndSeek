using System;
using UnityEngine;

namespace Skins
{
    public class SkinChanger : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Animator _animator;

        [Header("Data")]
        [SerializeField] private SkinRoot[] _skinRoots;
        
        #region MonoBehaviour

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
            _skinRoots = GetComponentsInChildren<SkinRoot>(true);
        }

        #endregion

        public void SetSkin(Skin skin)
        {
            foreach (var skinRoot in _skinRoots)
            {
                if (skin == skinRoot.Skin)
                {
                    skinRoot.gameObject.SetActive(true);
                    _animator.avatar = skinRoot.Avatar;
                }
                else
                {
                    skinRoot.gameObject.SetActive(false);
                }
            }
        }
    }
}
