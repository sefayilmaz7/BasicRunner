using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    // Creating instance for accesing it from everywhere
    public static SwerveMovement instance = null;
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    [HideInInspector] public bool canMove = false;
    private bool isStarted = false;
    public float speed = 0.1f;

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) 
        {
            if (!isStarted) 
            {
                StartGame();
            }
        }

        if (canMove)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.4f, 1.03f), transform.position.y, transform.position.z);

            float swerveAmount = Time.fixedDeltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);

            var smoothSwerveAmount = Mathf.Lerp(0, swerveAmount, 0.128f);

            transform.Translate(smoothSwerveAmount, 0, 0);

            transform.position += new Vector3(0, 0, speed);
        }
    }

    void StartGame()
    {
        canMove = true;
        isStarted = true;
    }
}