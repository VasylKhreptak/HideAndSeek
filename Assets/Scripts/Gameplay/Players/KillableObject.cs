using System;
using CBA.Events.Core;
using Interfaces.Entity;

namespace Gameplay.Players
{
    public class KillableObject : MonoEvent, IKillable
    {
        public event Action onKilled;

        public void Kill()
        {
            Invoke();
        }
    }
}
