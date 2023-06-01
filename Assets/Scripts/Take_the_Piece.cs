using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Take_the_Piece : MonoBehaviour
{
     public Text steps;
    public Transform toCut;
    public Transform toCut_Arrow;
    public Transform machine_Arrow;
   private void OnTriggerExit(Collider other)
    {
         if (other.gameObject == toCut.gameObject)
         {
           
            toCut_Arrow.gameObject.SetActive(false);
            machine_Arrow.gameObject.SetActive(true);
             steps.text = "Step 3"+"\n\n"+"now place the piece inside the machine to reshape it";
         }
    }
}
