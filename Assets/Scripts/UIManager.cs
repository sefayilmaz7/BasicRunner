using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public GameObject complete;
    public GameObject fail;
    public GameObject currentScoreBar;
    public GameObject totalScoreBar;
    public GameObject healthBar;
    public Text currentLevel;
    public Text healthText;
    public Text currentLevelScore;
    public Text totalScore;

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

    private void Update()
    {
        healthText.text = PlayerValues.instance.Health.ToString();
        currentLevelScore.text = PlayerValues.instance.CurrentScore.ToString();
        totalScore.text = PlayerValues.totalScore.ToString();
    }

    private void OnEnable()
    {
        EventManager.onGameFailed += ShowFailScreen;
        EventManager.onGameFinished += ShowWinScreen;
        EventManager.onGameStarted += ShowInGameUI;
    }

    private void OnDisable()
    {
        EventManager.onGameFailed -= ShowFailScreen;
        EventManager.onGameFinished -= ShowWinScreen;
        EventManager.onGameStarted -= ShowInGameUI;
    }

    void ShowFailScreen() 
    {
        fail.SetActive(true);
        currentScoreBar.transform.position = healthBar.transform.position;
        healthBar.SetActive(false);
    }

    void ShowWinScreen() 
    {
        complete.SetActive(true);
        currentScoreBar.transform.position = healthBar.transform.position;
        healthBar.SetActive(false);
        totalScoreBar.SetActive(true);
        StartCoroutine(TransferScore());
    }

    void ShowInGameUI() 
    {
        totalScoreBar.SetActive(false);
        currentScoreBar.SetActive(true);
    }

    private IEnumerator TransferScore() 
    {
        yield return new WaitForSeconds(0.5f);
        var iterationCount = PlayerValues.instance.CurrentScore;

        for (int i = 0; i < iterationCount; i++)
        {
            PlayerValues.instance.CurrentScore--;
            PlayerValues.totalScore++;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
