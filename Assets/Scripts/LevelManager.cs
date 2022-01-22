using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    [Space]
    public GameObject[] levels;
    [HideInInspector]
    public static int levelIndex = 1;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            var element = levels[i];
            if (i == PlayerPrefs.GetInt("level"))
            {
                // skip this one
                continue;
            }

            element.SetActive(false);
        }
    }

    private void OnEnable()
    {
        EventManager.onGameFinished += IncreaseLevel;
    }

    private void OnDisable()
    {
        EventManager.onGameFinished -= IncreaseLevel;
    }

    void IncreaseLevel() 
    {
        levelIndex++;
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

}
