using UnityEngine;

namespace Actions.Audio
{
    public abstract class AudioClipProvider : MonoBehaviour
    {
        public abstract AudioClip AudioClip { get; }
    }
}
