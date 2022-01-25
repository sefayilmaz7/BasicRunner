using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void CollectDiamond(GameObject collidedObject) 
    {
        GameObject particle = ObjectPool.instance.GetPooledObject();
        if (particle != null)
        {
            particle.transform.position = collidedObject.transform.position;
            particle.SetActive(true);
            particle.GetComponent<ParticleSystem>().Play();
        }
        Destroy(collidedObject);
        StartCoroutine(WaitAndDisableObject(particle));
    }


    private IEnumerator WaitAndDisableObject(GameObject objectToDisable) 
    {
        yield return new WaitForSeconds(2);
        objectToDisable.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable")) 
        {
            CollectDiamond(other.gameObject);
            EventManager.DiamondCollectWithEvent();
        }

        else if (other.CompareTag("Obstacle")) 
        {
            EventManager.HitObstacleWithEvent();
        }

        else if (other.CompareTag("Finish")) 
        {
            EventManager.FinishGameWithEvent();
        }
    }
}
