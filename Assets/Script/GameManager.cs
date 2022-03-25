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
    private bool callibrationInstruction = true;


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
                if (callibrationTime == 0f)
                {
                    callibrationText.text = "Installez-vous debout et reproduisez la position du coach et restez stable pendant 5 secondes.\n Restez sur le bouton B Gauche pour débuter la callibration.";
                    //TODO Coach T POSE
                }
                ControllerManager.leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPrimaryLeftButtonPressed);
                if (isPrimaryLeftButtonPressed )
                {
                    if (callibrationInstruction)
                    {
                        callibrationText.text = "";
                        callibrationInstruction = false;
                    }
                    else
                    {
                        updateTimer();
                    }
                }
                else
                {
                    callibrationTime = 0;
                }
                break;
        }
    }

    void updateTimer()
    {
        Debug.Log("GameManager : Starting Callibration");
        callibrationTime += Time.deltaTime;
        callibrationText.text = "Callibrating...\n" + callibrationTime.ToString("0.00");
        if (callibrationTime >= 3)
        {
            callibrationText.text = "Succès Début de la partie";
            state = GameState.Playing;
            

        }
    }
    
        
    
}
