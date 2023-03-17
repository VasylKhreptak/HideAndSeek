using UnityEngine;

namespace Extensions
{
    public static class TransformExtensions
    {
        public static Transform FarthestTransform(this Transform transform, Transform[] transforms)
        {
            Transform farthestTransform = null;
            float farthestDistance = 0f;

            foreach (Transform t in transforms)
            {
                float distance = Vector3.Distance(transform.position, t.position);

                if (distance > farthestDistance)
                {
                    farthestDistance = distance;
                    farthestTransform = t;
                }
            }

            return farthestTransform;
        }

        public static Transform ClosestTransform(this Transform transform, Transform[] transforms)
        {
            Transform closestTransform = null;
            float closestDistance = Mathf.Infinity;

            foreach (Transform t in transforms)
            {
                float distance = Vector3.Distance(transform.position, t.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTransform = t;
                }
            }

            return closestTransform;
        }
    }
}
