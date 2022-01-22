using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public GameObject complete;
    public GameObject fail;
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
        SetLevelTexts();
    }

    void SetLevelTexts() 
    {
        currentLevel.text = "LEVEL " + (PlayerPrefs.GetInt("level") + 1).ToString();
    }

    private void OnEnable()
    {
        EventManager.onGameFailed += ShowFailScreen;
        EventManager.onGameFinished += ShowWinScreen;
    }

    private void OnDisable()
    {
        EventManager.onGameFailed -= ShowFailScreen;
        EventManager.onGameFinished -= ShowWinScreen;
    }

    void ShowFailScreen() 
    {
        fail.SetActive(true);
    }

    void ShowWinScreen() 
    {
        complete.SetActive(true);
    }
}
