using Plugins.ObjectPooler;
using UnityEngine;

namespace Zenject.Installers
{
    public class ObjectPoolerInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private ObjectPooler _objectPooler;

        #region MonoBehaviour

        private void OnValidate()
        {
            _objectPooler ??= FindObjectOfType<ObjectPooler>();
        }

        #endregion

        public override void InstallBindings()
        {
            Container.BindInstance(_objectPooler).AsSingle();
        }
    }
}
