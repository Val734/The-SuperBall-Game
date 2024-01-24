using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using UnityEngine.Events; 

//SIngleton o contador est�tico de monedas enla clase COin (singleton es m�s easy) 
public class CoinCounter: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterText;
    //TextMeshProUGUI counterText;
    
    [SerializeField] Transform coinsPartent; 
    public int counter;

    public int pickedUpCoins;

    public UnityEvent WinCoindition; 

    //int StartCoinCount; 

    public UnityEvent WinMessage;
    // Start is called before the first frame update
    /*private void Awake()
    {
        counterText = GetComponentInChildren<TextMeshProUGUI>();
    }*/
    void Start()
    {
        //startCoinCount=Coin.count; 
        counter = coinsPartent.transform.childCount; 
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = $"{pickedUpCoins}/{counter}";

        if(pickedUpCoins==counter)
        {
            WinMessage.Invoke();
            WinCoindition.Invoke();
        }
       
        
    }
    public void CounterForCoinsTextUpdater()
    {
        pickedUpCoins++; 
    }


}
