using Extensions;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Volume _volume;
    [SerializeField] private Transform _seekPlayerTransform;
    [SerializeField] private Transform _hidePlayerTransform;

    [Header("Distance Preferences")]
    [SerializeField] private float _minPlayerDistance;
    [SerializeField] private float _maxPlayerDistance;

    [Header("Intensity Preferences")]
    [SerializeField, Range(0f, 1f)] private float _minIntensity;
    [SerializeField, Range(0f, 1f)] private float _maxIntensity;

    [Header("Color Preferences")]
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _targetColor;

    [Header("General Preferences")]
    [SerializeField] private AnimationCurve _curve;

    private Vignette _vignette;

    #region MonoBehaviour

    private void OnValidate()
    {
        _volume ??= FindObjectOfType<Volume>();
    }

    private void Awake()
    {
        _volume.profile.TryGet(out _vignette);
    }

    private void Update()
    {
        UpdateVignette();
    }

    #endregion

    private void UpdateVignette()
    {
        float distance = Vector3.Distance(_hidePlayerTransform.position, _seekPlayerTransform.position);

        _vignette.intensity.value = GetIntensity(distance);
        _vignette.color.value = GetColor();
    }

    private float GetIntensity(float distance)
    {
        return _curve.Evaluate(_minPlayerDistance, _maxPlayerDistance, distance, _maxIntensity, _minIntensity);
    }

    private Color GetColor()
    {
        return Color.Lerp(_startColor, _targetColor, _vignette.intensity.value);
    }

    private void OnDrawGizmosSelected()
    {
        if (_hidePlayerTransform == null) return;

        Gizmos.color = CBA.Extensions.Color.WithAlpha(Color.green, 0.4f);
        Vector3 position = _hidePlayerTransform.position;

        Gizmos.DrawSphere(position, _minPlayerDistance);

        Gizmos.color = CBA.Extensions.Color.WithAlpha(Color.red, 0.4f);
        Gizmos.DrawSphere(position, _maxPlayerDistance);
    }
}
