using System;

namespace Interfaces.Entity
{
    public interface IKillable
    {
        public event Action onKilled;

        public void Kill();
    }
}
