using System.Collections;
using System.Collections.Generic;
using Script;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{

    public GameState state;
    public TextMeshProUGUI callibrationText;
    private float callibrationTime = 0;
    private InputDevice leftController;
    private bool leftControllerConnected = false;
    private bool isPrimaryLeftButtonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Callibrate;
    }

    // Update is called once per frame
    void Update()
    {
    switch (state)
        {
            case GameState.Callibrate:
                if (!leftControllerConnected)    
                {
                    getLeftController();
                }
                else
                {
                    
                    leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPrimaryLeftButtonPressed);
                    if (isPrimaryLeftButtonPressed)
                    {
                        callibrationTime += Time.deltaTime;
                        callibrationText.text = "Callibrating...\n" + callibrationTime.ToString("0.00");
                        if (callibrationTime > 3)
                        {
                            callibrationText.text = "";
                        }
                    }
                    
                }
                break;
        }
    }

    private void getLeftController()
    {
        leftController = ControllerManager.leftController;
    }
        
    
}
