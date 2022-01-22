using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
    }


}