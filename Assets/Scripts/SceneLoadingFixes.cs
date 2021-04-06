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
    public Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        if (currentScene.ToString().Equals("Scenes/Level_1"))
        {
            if ((float)VariablesManager.GetGlobal("CollectedPiece1") == 1f)
                pieceToDelete1.SetActive(false);

            if ((float)VariablesManager.GetGlobal("CollectedPiece2") == 1f)
                pieceToDelete2.SetActive(false);

            if ((float)VariablesManager.GetGlobal("CollectedPiece3") == 1f)
                pieceToDelete3.SetActive(false);
        }

        // Correctly updates score when loading level
        float currentScore = (float)VariablesManager.GetGlobal("CollectedPieces");
        textScore.text = currentScore + "/3";
    }
}
