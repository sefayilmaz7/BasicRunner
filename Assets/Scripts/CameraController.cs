using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] private GameObject damageEffect;
    private float staticPositionY = 2.49f;
    private bool cameraFollow = true;


    private void LateUpdate()
    {
        if (cameraFollow)
        {
            var newPos = transform.position = playerTransform.position - offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, newPos, 0.1f);
            smoothPosition.y = staticPositionY;
            gameObject.transform.position = smoothPosition;
        }
    }

    private void OnEnable()
    {
        EventManager.onHitObstalce += TakeDamage;
        EventManager.onGameFinished += SetCameraToFinishScene;
    }

    private void OnDisable()
    {
        EventManager.onHitObstalce -= TakeDamage;
        EventManager.onGameFinished -= SetCameraToFinishScene;
    }

    private IEnumerator ApplyDamageEffect() 
    {
        damageEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        damageEffect.SetActive(false);
    }

    void TakeDamage() 
    {
        StartCoroutine(ApplyDamageEffect());
    }

    void SetCameraToFinishScene() 
    {
        StartCoroutine(MoveCameraByTime(0));
    }

    private IEnumerator MoveCameraByTime(float time) 
    {
        cameraFollow = false;
        while (time < 1)
        {
            time += Time.fixedDeltaTime;
            transform.position += new Vector3(0,0,0.2f);
            transform.Rotate(new Vector3(0,3.52f,0) , Space.Self);
            yield return null;
        }
    }

}
