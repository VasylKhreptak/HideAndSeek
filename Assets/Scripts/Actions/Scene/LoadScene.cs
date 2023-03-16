using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Action = CBA.Actions.Core.Action;

namespace Actions.Scene
{
    public class LoadScene : Action
    {
        [Header("Preferences")]
        [SerializeField, Scene] private string _sceneName;
        public override void Do()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
