using Plugins.AudioPooler;
using UnityEngine;
using Zenject;
using Action = CBA.Actions.Core.Action;
using AudioSettings = Plugins.AudioPooler.AudioSettings;

namespace Actions.Audio
{
    public class PlayOneShootSound : Action
    {
        [Header("References")]
        [SerializeField] private Transform _transform;
        [SerializeField] private AudioClipProvider _audioClipProvider;

        [Header("Preferences")]
        [SerializeField] private bool _playOnTransformPosition;
        [Space]
        [SerializeField] private AudioSettings _settings;

        private AudioPooler _audioPooler;

        [Inject]
        private void Construct(AudioPooler audioPooler)
        {
            _audioPooler = audioPooler;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _transform ??= GetComponent<Transform>();
            _audioClipProvider ??= GetComponent<AudioClipProvider>();
        }

        #endregion

        public override void Do()
        {
            Play();
        }

        public void Play()
        {
            _settings.clip = _audioClipProvider.AudioClip;
            _settings.playPosition = _transform.position;

            _audioPooler.Play(_settings);
        }
    }
}
