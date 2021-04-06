using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameCreator.Core;
using GameCreator.Variables;

public class MoveScene : MonoBehaviour
{
    [SerializeField] private string loadLevel;

    public Animator transition;

    public float transitionTime;

    private void Update()
    {
        if ((float)VariablesManager.GetGlobal("CollectedPieces") == 3f && (float)VariablesManager.GetGlobal("CompletedLevel1") == 0f)
        {
            VariablesManager.SetGlobal("CompletedLevel1", 1f);   
            StartCoroutine(LoadLevel());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !this.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(loadLevel);
    }
}
