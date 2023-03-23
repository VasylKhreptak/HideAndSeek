using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public static class CameraViewportFinder
    {
        public static Vector3 FindViewport(Vector3 targetPosition, int raycasts, float offset, float maxScanDistance, LayerMask obstacleMask)
        {
            float angleOffset = 360f / raycasts;

            List<RaycastHit> hitPoints = new List<RaycastHit>();

            float angle = 0f;
            for (int i = 0; i < raycasts; i++)
            {
                Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;
                Ray ray = new Ray(targetPosition, direction);
                angle += angleOffset;

                if (UnityEngine.Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, obstacleMask))
                {
                    hitPoints.Add(hitInfo);
                }
            }

            if (hitPoints.Count == 0)
            {
                Debug.Log("No hit points found");
                return targetPosition;
            }

            float maxDistance = 0f;
            int appropriatePointIndex = 0;
            for (int i = 0; i < hitPoints.Count; i++)
            {
                RaycastHit hitInfo = hitPoints[i];

                if (hitInfo.distance > maxDistance)
                {
                    maxDistance = hitInfo.distance;
                    appropriatePointIndex = i;
                }
            }
            
            float pointDistance = Mathf.Min(maxScanDistance, maxDistance);
            Vector3 appropriatePoint = hitPoints[appropriatePointIndex].point;
            Vector3 directionToPoint = (appropriatePoint - targetPosition).normalized;
            return targetPosition + directionToPoint * (pointDistance + offset);
        }
    }
}
