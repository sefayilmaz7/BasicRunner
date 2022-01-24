using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;
    private float staticPositionY = 2.49f;

    private void LateUpdate()
    {
        var newPos = transform.position = playerTransform.position - offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position , newPos , 0.1f);
        smoothPosition.y = staticPositionY;
        gameObject.transform.position = smoothPosition;
    }
}
