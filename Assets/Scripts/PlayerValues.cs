using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour
{
    public static PlayerValues instance = null;
    [Header("Money for each diamond")]
    [SerializeField] private int collectableValue = 1;
    public static int totalScore;
    private int currentScore;
    private int health = 3;
    public int CurrentScore { get { return currentScore; } set { currentScore = value; } }
    public int Health { get { return health; } set { health = value; } }
    public int CollectableValue { get { return collectableValue; }  set { collectableValue = value; } }



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        EventManager.onDiamondCollect += IncreaseScore;
        EventManager.onHitObstalce += DecreaseHealth;
    }

    private void OnDisable()
    {
        EventManager.onDiamondCollect -= IncreaseScore;
        EventManager.onHitObstalce -= DecreaseHealth;
    }

    void IncreaseScore() 
    {
        currentScore += collectableValue;
    }

    void DecreaseHealth() 
    {
        if (health > 1)
        {
            health--;
        }
        else 
        {
            EventManager.FailGameWithEvent();
        }
    }

}
