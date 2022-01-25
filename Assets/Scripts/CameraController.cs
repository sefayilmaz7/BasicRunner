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
        cameraFollow = false;
        transform.position = Vector3.Lerp(transform.position , transform.position + new Vector3(0,0,4) , 1);
        transform.rotation = Quaternion.Lerp(transform.rotation , Quaternion.Euler(0,180,0) , 1);
    }
}
