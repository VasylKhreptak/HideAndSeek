using System;
using CBA.Events.Core;
using Interfaces.Entity;

namespace Gameplay.Players
{
    public class KillableObject : MonoEvent, IKillable
    {
        public event Action onKilled;

        private bool _isKilled;

        public bool IsKilled => _isKilled;

        public void Kill()
        {
            Invoke();

            _isKilled = true;
        }
    }
}
