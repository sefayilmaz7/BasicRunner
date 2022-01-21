using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public GameObject Complete;
    public GameObject Fail;
    public Text currentLevel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        currentLevel.text = "LEVEL " + (PlayerPrefs.GetInt("level") > 0 ? PlayerPrefs.GetInt("level") : LevelManager.levelIndex).ToString();
    }
}
