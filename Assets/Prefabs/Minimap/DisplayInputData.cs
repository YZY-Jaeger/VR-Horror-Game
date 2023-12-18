using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{

    private InputData _inputData;
    private float _leftMaxScore = 0f;
    private float _rightMaxScore = 0f;
    public GameObject CanvasMinimap;

    private bool _wasLeftPrimaryButtonPressed = false;
    private void Start()
    {
        _inputData = GetComponent<InputData>();
        CanvasMinimap.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        // Check if the primary button on the left controller is released after being pressed
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isLeftPrimaryButtonPressed))
        {
            if (_wasLeftPrimaryButtonPressed && !isLeftPrimaryButtonPressed)
            {
                Debug.Log("Left primary button released!");
                if (CanvasMinimap.activeInHierarchy) { CanvasMinimap.SetActive(false); }
                else {CanvasMinimap.SetActive(true); }
                
            }

            _wasLeftPrimaryButtonPressed = isLeftPrimaryButtonPressed;
        }
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
        {
            _rightMaxScore = Mathf.Max(rightVelocity.magnitude, _rightMaxScore);
            //rightScoreDisplay.text = _rightMaxScore.ToString("F2");
        }
    }





}
