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
                    callibrationText.text = "Installez-vous debout et reproduisez la position du coach, restez stable et détendu pendant 5 secondes.\nRestez sur le bouton B Gauche pour débuter la callibration.\nPréparez vous à une grande détente...";
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
                callibrationText.text = "Début de la partie, reproduisez la position du coach pendant 5 secondes : " + PositionMatcher.getCurrentPercentage() + "% \nEt surtout, détendez vous...";
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
                callibrationText.text = "Bravo, animation suivante... \nDétente maximale...";
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
        callibrationText.text = "Préparez vous... \nPrenez une grande inspiration... \nEt détendez vous...";
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

        if (callibrationTime >= 3)
        {
            positionDetection.tailleJoueur = PositionMatcher.getHeadPosition().y;

            callibrationText.text = "Reproduisez la position du coach pendant 5 secondes... \nEt détendez vous...";
            state = GameState.Playing;

        }
    }
    
}
