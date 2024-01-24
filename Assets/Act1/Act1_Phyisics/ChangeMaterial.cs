using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] GameObject PlayerBall;
    [SerializeField] PlayerMaterial[] availableMaterials;
    [SerializeField] TMP_Dropdown dropdown; 

    //para que la clase salga en el inspector sino no sale con lo de system.serializable
    [System.Serializable]
    class PlayerMaterial
    {
        public string name; 
        public Material material;
    }
    private void Start()
    {
        dropdown.ClearOptions();//borrar las opciones que ya hay (la de los colorines lila, negro azul ya existentes y le añadimos el orden que hay en el array más abajo)
        
        List <string> newOptions = new List <string>();

        foreach(PlayerMaterial pm in availableMaterials) { newOptions.Add(pm.name); }
        dropdown.AddOptions(newOptions);
    }
    public void OnDropdownValueChanged(int selectedMaterial)
    {
        ApplyMaterial(availableMaterials[selectedMaterial].material);

        //switch (selectedMaterial)
        //{
        //
        //    case 0:
        //        ApplyMaterial(availableMaterials[0].material);
        //        break;
        //
        //    case 1:
        //        ApplyMaterial(availableMaterials[1].material);
        //        break;
        //
        //    case 2:
        //        ApplyMaterial(availableMaterials[2].material);
        //        break;
        //
        //    default://esto establece que si no se da ninguno de los casos se hace esto
        //        Debug.Log("El valor elegido no está soportado.");
        //        break;
        //}
    }
    void ApplyMaterial(Material material)
    {
        PlayerBall.GetComponent<MeshRenderer>().material = material;  
    }
}
