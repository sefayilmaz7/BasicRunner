using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementalSystem : MonoBehaviour
{
    private static int boughtHealthLevel = 0;
    private static int boughtValueLevel = 0;

    enum Items 
    {
        health = 10,
        collectValue = 10
    }
    private void Start()
    {
        PlayerValues.instance.Health += boughtHealthLevel;
        PlayerValues.instance.CollectableValue += boughtValueLevel;
    }

    public void BuyHealth() 
    {
        if(PlayerValues.totalScore >= (int)Items.health) 
        {
            boughtHealthLevel++;
            PlayerValues.totalScore -= (int)Items.health;
            PlayerValues.instance.Health++;
            gameObject.SetActive(false);
        }
    }

    public void BuyCollectValue() 
    {
        if (PlayerValues.totalScore >= (int)Items.collectValue)
        {
            boughtValueLevel++;
            PlayerValues.totalScore -= (int)Items.collectValue;
            PlayerValues.instance.CollectableValue++;
            gameObject.SetActive(false);
        }
    }
}
