using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float lastFrameFingerPositionX;
    private float moveFactorX;
    public float MoveFactorX => moveFactorX;

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }


}