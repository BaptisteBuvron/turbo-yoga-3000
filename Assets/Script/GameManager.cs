using System.Collections;
using System.Collections.Generic;
using Assets.Positions;
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
    private float animationTime = 0;
    
    
    

    public PositionDetection positionDetection;


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
                    callibrationText.text = "Installez-vous debout et reproduisez la position du coach et restez stable et détendu pendant 5 secondes.\n Restez sur le bouton B Gauche pour débuter la callibration.";
                    Trainer.playAnimation(Animations.Tpose);
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
            case GameState.Playing:
                callibrationText.text = "Début de la partie, reproduisez la position du coach : " + PositionMatcher.getCurrentPercentage() + "%";
                if (animationTime > 5)
                {
                    animationTime = 0;
                    state = GameState.ChangeAnimation;
                }
                else if (PositionMatcher.getCurrentPercentage() >= 100f)
                {
                    animationTime += Time.deltaTime;
                }
                else
                {
                    animationTime = 0;
                }
                break;
            case GameState.ChangeAnimation :
                callibrationText.text = "Bravo, animation suivante... \n détente maximale...";
                state = GameState.ChangingAnimation;
                Invoke("hideText", 2);
                Invoke("nextAnimation", 2);
                break;
            default:
                break;
        }
    }

    private void hideText()
    {
        callibrationText.text = "";
    }

    private void nextAnimation()
    {
        Trainer.playRandomAnimation();
        callibrationText.text = "Préparez vous... \n Prenez une grande inspiration... \n et détendez vous...";
        Invoke("setPlayingState", 3);

    }

    private void setPlayingState()
    {
        state = GameState.Playing;

    }

    void updateTimer()
    {
        Debug.Log("Calibration en cours, détendez vous...");
        callibrationTime += Time.deltaTime;
        callibrationText.text = "Calibration en cours, détendez vous... \n" + callibrationTime.ToString("0.00");
        if (callibrationTime <= 2.5f)
        {
            positionDetection.tailleJoueur = PositionMatcher.getHeadPosition().y;
        }
        if (callibrationTime >= 3)
        {
            callibrationText.text = "Début de la partie, reproduisez la position du coach, et détendez vous...";
            state = GameState.Playing;
        }
    }
    
}
