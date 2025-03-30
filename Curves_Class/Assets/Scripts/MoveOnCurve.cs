using UnityEngine;

public class MoveOnCurve : MonoBehaviour
{
    [SerializeField] private Curve _curve = null;
    [SerializeField] private float _speed = 1.0f;
    private float _currentPointOnCurve = 0f;
    private int _direction = 1; // Direction 1 = forward, -1 = backward.

    private void Update()
    {
        // Increase point on curve each frame forward and backward based on direction.
        _currentPointOnCurve += Time.deltaTime * _speed * _direction;

        // If the object reaches the other end of the curve, reverse direction.
        if (_currentPointOnCurve >= 1)
        {
            _currentPointOnCurve = 1; // Clamp current point at 1
            _direction = -1;
        }
        else if (_currentPointOnCurve < 0)
        {
            _currentPointOnCurve = 0; // Clamp current point at 0
            _direction = 1;
        }
        
        // Move the object along the curve using curves lerp method and current point on curve.
        transform.position = _curve.GetPoint(_currentPointOnCurve);
    }
}