using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public GameObject complete;
    public GameObject fail;
    [SerializeField] GameObject currentScoreBar;
    [SerializeField] GameObject totalScoreBar;
    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject dragTutorial;
    [SerializeField] Text currentLevel;
    [SerializeField] Text healthText;
    [SerializeField] Text currentLevelScore;
    [SerializeField] Text totalScore;

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
        dragTutorial.SetActive(false);
        shop.SetActive(false);
        totalScoreBar.SetActive(false);
        currentScoreBar.SetActive(true);
    }

    private IEnumerator TransferScore() 
    {
        yield return new WaitForSeconds(0.5f);
        totalScore.color = Color.green;
        var iterationCount = PlayerValues.instance.CurrentScore;

        for (int i = 0; i < iterationCount; i++)
        {
            PlayerValues.instance.CurrentScore--;
            PlayerValues.totalScore++;
            yield return new WaitForSeconds(0.1f);
        }
        totalScore.color = Color.white;
    }
}
