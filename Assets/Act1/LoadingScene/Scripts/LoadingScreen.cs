using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadingScreen : MonoBehaviour
{
   static LoadingScreen instance; 

    [SerializeField] string firstSceneToLoad; 
    //elemento que hace que todos los elementos del UI hagan fade
    CanvasGroup canvasGroup;
    Scene lastLoadScene;

    public void Awake()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();
        instance= this;
    }
   private void Start()
    {
        LoadScene(firstSceneToLoad);
    }

    public static void LoadScene(string sceneName)
    {
        //throw new System.Exception("Not implemented!");
        instance.LoadSceneInternal(sceneName); 
    }
    public void LoadSceneInternal(string sceneName)
    {
        //throw new System.Exception("Not implemented!");
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        if (lastLoadScene.isLoaded)
        {
            // HacemeUnFadeOut(); 
            Tween fadeOut= canvasGroup.DOFade(1f, 2f); 
            while(!fadeOut.playedOnce)
            {
                yield return null;
            }

            AsyncOperation unloadOperation= SceneManager.UnloadSceneAsync(lastLoadScene);

            while (!unloadOperation.isDone)
            {
                yield return null;
            }
        }
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!loadOperation.isDone)
        {
            yield return null;
        }
        lastLoadScene= SceneManager.GetSceneByName(sceneName);
        Tween fadeIn = canvasGroup.DOFade(0f, 2f);

        while (!fadeIn.playedOnce)
        {
            yield return null;
        }

    }

}
