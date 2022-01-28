using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator playerAnimator;

    private void OnEnable()
    {
        EventManager.onGameStarted += StartRunning;
        EventManager.onGameFailed += BackToIdle;
        EventManager.onGameFinished += StartVictory;
    }

    private void OnDisable()
    {
        EventManager.onGameStarted -= StartRunning;
        EventManager.onGameFailed -= BackToIdle;
        EventManager.onGameFinished -= StartVictory;
    }

    void StartRunning() 
    {
        playerAnimator.SetTrigger("Run");
    }

    void StartVictory() 
    {
        playerAnimator.SetTrigger("Win");
    }

    void BackToIdle() 
    {
        playerAnimator.SetTrigger("Fail");
    }
}
