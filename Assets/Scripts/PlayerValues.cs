using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour
{
    public static PlayerValues instance = null;
    public static int totalScore;
    private int currentScore;
    private int health = 3;
    public int CurrentScore { get { return currentScore; } set { currentScore = value; } }
    public int Health { get { return health; } set { health = value; } }

    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}
