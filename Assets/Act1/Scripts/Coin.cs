using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 


public class Coin : MonoBehaviour
{
    static public int count;
    ///--> ¡static es que ese miembro es de la clase coin, lo comparten todos los coins; 

    //bool alreadyPickedUp=false; 

    Animator animator;
    AudioSource pickupAudioSource; 
    public UnityEvent PickedCoin; 

    private void Awake()
    {
        count++;
        animator =GetComponentInChildren<Animator>();
        pickupAudioSource= GetComponentInChildren<AudioSource>();

        //
    }
    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("PickedUp");//tiene que tener el mismo nombre
        Destroy(gameObject, 5f); 
        PickedCoin.Invoke(); 
        //pickupAudioSource.Play();  
        //alreadyPickedUp = true;
    }
    private void OnDestroy()
    {
      count--;
      Debug.Log(count);
    }
}
