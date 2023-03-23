using Gameplay;
using UnityEngine;

[ExecuteAlways]
public class CameraViewportFinderTest : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private int _raycasts = 10;
    [SerializeField] private float _offset;
    [SerializeField] private float _maxScanDistance;
    [SerializeField] private LayerMask _obstacleMask;

    private void OnDrawGizmos()
    {
        Vector3 cameraPosition = CameraViewportFinder.FindViewport(transform.position, _raycasts, _offset, _maxScanDistance, _obstacleMask);
        
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(cameraPosition, 0.5f);
        Gizmos.color = CBA.Extensions.Color.WithAlpha(Color.green, 0.3f);
        Gizmos.DrawSphere(transform.position, _maxScanDistance);
    }
}
