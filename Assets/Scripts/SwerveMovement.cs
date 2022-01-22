using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    // Creating instance for accesing it from everywhere
    public static SwerveMovement instance = null;
    #region Variables
    private PlayerInput playerInput;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    [HideInInspector] public bool canMove = false;
    public float speed = 0.1f;
    #endregion

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        EventManager.onGameStarted += StartMoving;
        EventManager.onGameFinished += StopMoving;
        EventManager.onGameFailed += StopMoving;
    }

    private void OnDisable()
    {
        EventManager.onGameStarted -= StartMoving;
        EventManager.onGameFinished -= StopMoving;
        EventManager.onGameFailed -= StopMoving;
    }


    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.4f, 1.03f), transform.position.y, transform.position.z);

            float swerveAmount = Time.fixedDeltaTime * swerveSpeed * playerInput.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);

            var smoothSwerveAmount = Mathf.Lerp(0, swerveAmount, 0.128f);

            transform.Translate(smoothSwerveAmount, 0, 0);

            transform.position += new Vector3(0, 0, speed);
        }
    }

    void StartMoving()
    {
        canMove = true;
    }

    void StopMoving() 
    {
        canMove = false;
    }
}