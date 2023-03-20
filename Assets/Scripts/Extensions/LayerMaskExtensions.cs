using UnityEngine;

namespace Extensions
{
    public static class LayerMaskExtensions
    {
        public static int GetIndex(this LayerMask layerMask)
        {
            var layer = 0;
            var mask = layerMask.value;
            while (mask > 0)
            {
                mask >>= 1;
                layer++;
            }
            return layer - 1;
        }
    }
}
