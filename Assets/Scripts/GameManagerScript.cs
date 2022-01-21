using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;

    public IEnumerator WaitAndShowSucces()
    {
        yield return new WaitForSeconds(1.5f);
        LevelManager.levelIndex++;
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        UIManager.instance.Complete.SetActive(true);
        
    }

    public IEnumerator WaitAndShowFail()
    {
        yield return new WaitForSeconds(.5f);
        UIManager.instance.Fail.SetActive(true);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
