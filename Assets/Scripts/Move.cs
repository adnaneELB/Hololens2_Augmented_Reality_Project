using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Move : MonoBehaviour
{
    public Text steps;
    public Transform btn_Arrow;
    public Transform on_Arrow;
    public Transform piece_Arrow;
     public Transform final_shape_arrow;
    public Transform doorPosition;
    public Transform targetPosition;
    public Transform referencia;
    public float speed =0.5f;
    public AudioSource doorAudio;

    public GameObject luzInterior;
    public GameObject luzExterior;
    bool click = false;
  
    int arrow=0;
    int arrow2=0;

    // bool opening;
    // bool closing;


    // Start is called before the first frame update
    void Start()
    {    
         
         luzInterior.SetActive(true);
         luzExterior.SetActive(true);
      

    }

    public void clickMe(){
        doorAudio.Play();
        if(click == false){
            arrow++;
            click =true;
            if(arrow==1){
             btn_Arrow.gameObject.SetActive(false);
             piece_Arrow.gameObject.SetActive(true); 
             steps.text = "Step 2"+"\n\n"+"To your left, grab the piece from the table";
            }
            if(arrow==2){
                steps.text = "Step 8"+"\n\n"+"you can take the reshaped pieace now ";
                final_shape_arrow.gameObject.SetActive(true); 
            }
            
        }else{
           
            click = false;
              arrow2++;
            if(arrow2==1){
                on_Arrow.gameObject.SetActive(true);
                btn_Arrow.gameObject.SetActive(false);
                steps.text = "Step 5"+"\n\n"+"Now click the ON button on the panel to start the machine";
            }
        }
    }

    void Update()
    {
        if(click){
            
               

             luzInterior.SetActive(false);
             luzExterior.SetActive(false);
             move(doorPosition.position, targetPosition.position);             
        
        }
        if(!click){
           
             move(doorPosition.position, referencia.position);
             
             if (Vector3.Distance(doorPosition.position, targetPosition.position) < 0.01f){
        

                luzInterior.SetActive(true);
                luzExterior.SetActive(true);
              
                 //LeftC.transform.Rotate(0,40,0);
 
    
            
        }
        
    }
    }

    void move(Vector3 pos, Vector3 target){
        doorPosition.position = Vector3.MoveTowards(pos, target,speed * Time.deltaTime);
    }
 
}