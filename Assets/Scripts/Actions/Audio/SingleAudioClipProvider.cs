using UnityEngine;

namespace Actions.Audio
{
    public class SingleAudioClipProvider : AudioClipProvider
    {
        [Header("Preferences")]
        [SerializeField] private AudioClip _audioClip;

        public override AudioClip AudioClip => _audioClip;
    }
}
