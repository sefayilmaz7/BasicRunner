using System;
using UnityEngine;

public enum MovementTypes
{
    Slider, Joystick
}

public class MovementController : MonoBehaviour
{
    bool canMoveForward = false;
    bool canMoveHorizontal = false;

    #region Movement Settings

    public SliderProperties _SliderProperties;


    float firstClick = 0;
    #endregion


    public float playerSpeed = 0.01f;
    [HideInInspector] public float playerSpeedChangeable = 0f;
    private bool isStarted = false;

    [SerializeField] private bool UseModelRotate = true;
    [SerializeField] private float _ModelRotationSpeed = 5;
    [SerializeField] private float _ModelRotatePowerValue = 1f;
    [SerializeField] private float _ModelRotateMinMaxValue = 1f;

    [SerializeField] Transform model_Transform;
    [SerializeField] Transform parent_Transform;

    #region Properties
    [Serializable]
    public class SliderProperties
    {
        [HideInInspector] public float _VerticalSpeed = 5;
        [HideInInspector] public float _HorizontalSpeed = 1;

        [HideInInspector] public float _DeltaHorizontalValue;
        [HideInInspector] public float _ForwardValue;
    }

    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;


    void GameStarted(object[] a)
    {
        canMoveForward = true;
        canMoveHorizontal = true;

    } // GameStarted()

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void FixedUpdate()
    {
        _SliderProperties._ForwardValue = 0;

        #region Slider
        _SliderProperties._ForwardValue = _SliderProperties._VerticalSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {


            _SliderProperties._DeltaHorizontalValue = 0;

            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            {
                firstClick = Input.mousePosition.x;
            }
            else
            {
                firstClick = (Input.GetTouch(0).position.x + Screen.width);
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (!isStarted)
            {
                StartGame();
            }

            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
            {
                float delta = (Input.mousePosition.x - firstClick);

                _SliderProperties._DeltaHorizontalValue = (delta * _SliderProperties._HorizontalSpeed) * Time.deltaTime;
                firstClick = Input.mousePosition.x;
            }
            else
            {
                float delta = ((Input.GetTouch(0).position.x + Screen.width) - firstClick);

                _SliderProperties._DeltaHorizontalValue = (delta * _SliderProperties._HorizontalSpeed) * Time.deltaTime;
                firstClick = (Input.GetTouch(0).position.x + Screen.width);
            }
        }
        else
        {
            _SliderProperties._DeltaHorizontalValue = 0;
        }

        #endregion


        #region Movement

        Quaternion currentRot = model_Transform.rotation;
        float newRotY = 0;

        Vector3 newDirection = Vector3.zero;
        Vector3 currentPos = Vector3.zero;

        #region Rotation
        if (UseModelRotate && canMoveHorizontal)
        {
            currentRot.y = newRotY;
            newRotY = Mathf.Clamp(currentRot.y + (_SliderProperties._DeltaHorizontalValue * _ModelRotatePowerValue), -_ModelRotateMinMaxValue, _ModelRotateMinMaxValue);
            currentRot.y = newRotY;
            model_Transform.rotation = Quaternion.Lerp(model_Transform.rotation, currentRot, Time.deltaTime * _ModelRotationSpeed);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.21f, 0.21f), transform.position.y, transform.position.z);

        float swerveAmount = Time.fixedDeltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);

        var smoothSwerveAmount = Mathf.Lerp(0, swerveAmount, 0.128f);

        if (canMoveHorizontal)
        {
            transform.Translate(smoothSwerveAmount, 0, 0); 
        }
        #endregion

        transform.position += new Vector3(0,0,playerSpeedChangeable);


        #endregion
        #endregion
    }


    private void StartGame()
    {
        //UIManager.instance.dragTutorial.SetActive(false);
        UseModelRotate = true;
        canMoveHorizontal = true;
        playerSpeedChangeable = playerSpeed;
        isStarted = true;
    }
} // class
