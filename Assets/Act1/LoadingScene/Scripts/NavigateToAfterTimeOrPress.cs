using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class NavigateToAfterTimeOrPress : MonoBehaviour
{
    [SerializeField] string sceneToNavigateTo;
    [SerializeField] float waitTime = 2f;
    //[SerializeField] InputActionReference skip; 

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(NavigateToNextScene), waitTime); 
        //TODO: rsponder al skip
    }
    public void NavigateToNextScene()
    {
        LoadingScreen.LoadScene(sceneToNavigateTo);
    }
 
    
}
