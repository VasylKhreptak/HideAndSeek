using NaughtyAttributes;
using UnityEngine;

namespace Mesh
{
    public class EnableMeshRenderers : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _transform;

        [Header("Preferences")]
        [SerializeField] private MeshRenderer[] _meshRenderers;

        #region MonoBehaviour

        private void OnValidate()
        {
            _transform ??= GetComponent<Transform>();

            if (_transform == null) return;

            _meshRenderers = GetRenderers();
        }

        #endregion

        [Button("Enable Mesh Renderers")]
        public void EnableMeshRenderersButton()
        {
            foreach (MeshRenderer meshRenderer in _meshRenderers)
            {
                meshRenderer.enabled = true;
            }
        }

        private MeshRenderer[] GetRenderers()
        {
            return _transform.GetComponentsInChildren<MeshRenderer>(true);
        }
    }
}
