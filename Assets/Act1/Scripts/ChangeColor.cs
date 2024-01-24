using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    //hacer un script que cambie de color el material de un objeto; 
    //      Propiedades del Script: 
    //      -Color1: color al que hay que cambiar
    //
    //      Propiedades opcionales; 
    //      - ColorList: Lista de colores por los que hay que pasar
    //      - time: tiempo para transicionar de un color al siguiente

    // Start is called before the first frame update


    [SerializeField] Color color = Color.cyan;//se parece al colorado; el serializeField es un ATRIBUTO
    //con el public puedes pillarla desde un otro script 
    //el serializeField es un aoperacion por la que convertimos los obejtos de la escena en texto q7ue luego guardamos en memo9ria o en el disco. 
    //
    public Color colorin;//public color que muestra unity como no tiene ningún valor por defecto sale en negro con transparencia a 0; 
    public Color colorado= Color.red;// tiene un valor inicial. 


    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = color;
        //renderer.sharedMaterial.color = new Color(1f, 0f, 1f, 1f);

    }

    // Update is called once per frame
    void OnDestroy()
    {
        Renderer renderer = GetComponent<Renderer>();

        Destroy(renderer.material);
    }
}
