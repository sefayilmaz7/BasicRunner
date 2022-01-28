using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class EventManager: MonoBehaviour
{
    public delegate void GameStartedDelegate();
    public static event GameStartedDelegate onGameStarted;

    public delegate void GameFinishedDelegate();
    public static event GameFinishedDelegate onGameFinished;

    public delegate void GameFailedDelegate();
    public static event GameFailedDelegate onGameFailed;

    public delegate void DiamondCollectDelegate();
    public static event DiamondCollectDelegate onDiamondCollect;

    public delegate void HitObstacleDelegate();
    public static event HitObstacleDelegate onHitObstalce;


    public static void StartGameWithEvent()
    {
        onGameStarted();
    }

    public static void FinishGameWithEvent() 
    {
        onGameFinished();
    }

    public static void DiamondCollectWithEvent() 
    {
        onDiamondCollect();
    }

    public static void HitObstacleWithEvent() 
    {
        onHitObstalce();
    }

    public static void FailGameWithEvent() 
    {
        onGameFailed();
    }

}
