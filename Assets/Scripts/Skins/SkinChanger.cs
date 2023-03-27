using UnityEngine;

namespace Skins
{
    public class SkinChanger : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;


        #region MonoBehaviour

        private void OnValidate()
        {
            _skinnedMeshRenderer ??= GetComponent<SkinnedMeshRenderer>();
            _skinnedMeshRenderer ??= GetComponentInChildren<SkinnedMeshRenderer>();
        }

        #endregion

        public void SetSkin(Skin skin)
        {
            _skinnedMeshRenderer.sharedMesh = skin.mesh;
            _skinnedMeshRenderer.sharedMaterial = skin.material;
        }
    }
}
