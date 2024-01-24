using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [Header("Cutscene")]

    [SerializeField] GameObject victoryCutscene;
    [Header("Scene After Victory Functionality")]
    [SerializeField] string sceneAfterVictoryName;
    //[SerializeField] float timeToLoadSceneAfterVictory = 5f; 
    bool winConditionDetected;

    // Update is called once per frame
    // void Update()
    // {
    //     if (!winConditionDetected)
    //     {
    //         if (Coin.count <= 0)
    //         {
    //             winConditionDetected = true;
    //             victoryCutscene.SetActive(true);
    //             Invoke(nameof(GoToSceneAfterVictory), 5f);
    //
    //         }
    //     }
    // }
    private void Start()
    {
        StartCoroutine(CheckConditionCoroutine());
    }
    IEnumerator CheckConditionCoroutine()
    {
        do 
        {
            yield return new WaitForSeconds(1f);
        } 
        while (Coin.count > 0);

        victoryCutscene.SetActive(true);

        yield return new WaitForSeconds(5f);
        
        GoToSceneAfterVictory();
    }
    void GoToSceneAfterVictory()
    {
        SceneManager.LoadScene(sceneAfterVictoryName);
    }
}
