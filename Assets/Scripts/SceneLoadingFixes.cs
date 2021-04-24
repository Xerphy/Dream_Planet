using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCreator.Variables;
using UnityEngine.UI;

public class SceneLoadingFixes : MonoBehaviour
{
    [SerializeField] private string currentScene;

    public GameObject pieceToDelete1;
    public GameObject pieceToDelete2;
    public GameObject pieceToDelete3;
    public GameObject pieceToDelete4;
    public GameObject pieceToDelete5;
    public GameObject pieceToDelete6;
    public GameObject pieceToDelete7;
    public Slider musicSlider;
    public Slider fxSlider;
    public Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        // Removes collected pieces when loading level
        if (pieceToDelete1 != null)
        {
            if (currentScene.ToString().Equals("Scenes/Level_1"))
            {
                if ((float)VariablesManager.GetGlobal("CollectedPiece1") == 1f)
                    pieceToDelete1.SetActive(false);

                if ((float)VariablesManager.GetGlobal("CollectedPiece2") == 1f)
                    pieceToDelete2.SetActive(false);

                if ((float)VariablesManager.GetGlobal("CollectedPiece3") == 1f)
                    pieceToDelete3.SetActive(false);

                if ((float)VariablesManager.GetGlobal("CollectedPiece4") == 1f)
                    pieceToDelete4.SetActive(false);

                if ((float)VariablesManager.GetGlobal("CollectedPiece5") == 1f)
                    pieceToDelete5.SetActive(false);

                if ((float)VariablesManager.GetGlobal("CollectedPiece6") == 1f)
                    pieceToDelete6.SetActive(false);

                if ((float)VariablesManager.GetGlobal("CollectedPiece7") == 1f)
                    pieceToDelete7.SetActive(false);
            }
        }

        // Fixes volume sliders being messed up on scene load
        musicSlider.value = (float)VariablesManager.GetGlobal("MusicMix");
        fxSlider.value = (float)VariablesManager.GetGlobal("FXMix");

        // Correctly updates score when loading level
        float currentScore = (float)VariablesManager.GetGlobal("CollectedPieces");
        if (textScore != null)
        {
            textScore.text = currentScore + "/7";
        }
    }
}
