using CBA.Extensions;
using UnityEngine;

namespace Actions.Audio
{
    public class RandomAudioClipProvider : AudioClipProvider
    {
        [Header("Preferences")]
        [SerializeField] private AudioClip[] _audioClips;

        public override AudioClip AudioClip => _audioClips.Random();
    }
}
