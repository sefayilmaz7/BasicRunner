using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;

    [Space]

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;

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
        if (PlayerPrefs.GetInt("level") == 0)
            PlayerPrefs.SetInt("level", 1);

        switch (PlayerPrefs.GetInt("level") > 0 ? PlayerPrefs.GetInt("level") : levelIndex)
        {
            case 1:
                level1.SetActive(true);
                break;
            case 2:
                level1.SetActive(false);
                level2.SetActive(true);
                break;
            case 3:
                level1.SetActive(false);
                level2.SetActive(false);
                level3.SetActive(true);
                break;
            case 4:
                level1.SetActive(false);
                level2.SetActive(false);
                level3.SetActive(false);
                level4.SetActive(true);
                break;
            case 5:
                level1.SetActive(false);
                level2.SetActive(false);
                level3.SetActive(false);
                level4.SetActive(false);
                level5.SetActive(true);
                break;
            default:
                #region Totally Random Level Generate
                var randomIndex = Random.Range(0, 4);
                GameObject[] levels = { level1, level2, level3, level4, level5 };
                var randomLevel = levels[randomIndex];



                if (PlayerPrefs.GetInt("lastlevel") - 4 != randomIndex)
                {
                    randomLevel.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("lastlevel") - 4 == randomIndex && randomIndex > 0)
                {
                    levels[randomIndex - 1].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("lastlevel") - 4 == randomIndex && randomIndex == 0)
                {
                    levels[randomIndex + 1].SetActive(true);
                }
                #endregion
                break;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("level", levelIndex);
        PlayerPrefs.Save();
    }
}
