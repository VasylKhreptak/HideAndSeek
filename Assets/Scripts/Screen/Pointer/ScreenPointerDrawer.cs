using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Screen.Pointer
{
    public class ScreenPointerDrawer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _viewPort;

        [Header("Preferences")]
        [SerializeField] private List<Pointer> _pointers = new List<Pointer>();

        #region MonoBehaviour

        private void OnValidate()
        {
            _camera = Camera.main;

            _pointers ??= FindObjectsOfType<Pointer>().ToList();
        }

        private void Awake()
        {
            _viewPort ??= GetComponent<Transform>();
        }

        private void Update()
        {
            for (int i = 0; i < _pointers.Count; i++)
            {
                Pointer pointer = _pointers[i];

                if (pointer.enabled == false) continue;

                DrawPointer(pointer);
            }
        }

        #endregion

        public void AddPointer(Pointer pointer)
        {
            _pointers.Add(pointer);
        }

        public void RemovePointer(Pointer pointer)
        {
            _pointers.Remove(pointer);
        }

        private void DrawPointer(Pointer pointer)
        {
            Vector3 viewportPosition = _viewPort.position;
            Vector3 pointerPosition = pointer.transform.position;
            Vector3 toPointer = pointerPosition - viewportPosition;

            Ray ray = new Ray(viewportPosition, toPointer);

            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

            TranslatePlanes(planes, pointer);

            float minDistance = GetMinDistance(planes, ray);
            float distanceToPointer = toPointer.magnitude;

            pointer.isOnScreen.Value = distanceToPointer < minDistance;

            minDistance = Mathf.Min(minDistance, distanceToPointer);

            Vector3 worldPosition = ray.GetPoint(minDistance);
            Vector3 pointerScreenPoint = _camera.WorldToScreenPoint(worldPosition);
            pointer.PointerTransform.position = pointerScreenPoint;

            Vector3 viewportScreenPosition = _camera.WorldToScreenPoint(viewportPosition);
            float angle = Mathf.Atan2(pointerScreenPoint.y - viewportScreenPosition.y, pointerScreenPoint.x - viewportScreenPosition.x) * Mathf.Rad2Deg;
            pointer.PointerTransform.rotation = Quaternion.Euler(0, 0, angle + pointer.AngleOffset);
        }

        private float GetMinDistance(Plane[] planes, in Ray ray)
        {
            float minDistance = Mathf.Infinity;

            for (int i = 0; i < 4; i++)
            {
                if (planes[i].Raycast(ray, out float distance))
                {
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                    }
                }
            }

            return minDistance;
        }

        private void TranslatePlanes(Plane[] planes, Pointer pointer)
        {
            Transform cameraTransform = _camera.transform;
            Vector3 right = cameraTransform.right;
            Vector3 up = cameraTransform.up;
            planes[0] = Plane.Translate(planes[0], -right * pointer.LeftOffset);
            planes[1] = Plane.Translate(planes[1], right * pointer.RightOffset);
            planes[2] = Plane.Translate(planes[2], -up * pointer.DownOffset);
            planes[3] = Plane.Translate(planes[3], up * pointer.UpOffset);
        }
    }
}
