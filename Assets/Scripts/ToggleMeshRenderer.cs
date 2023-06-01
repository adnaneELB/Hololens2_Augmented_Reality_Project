using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ToggleMeshRenderer : MonoBehaviour
{
     public Text steps;
    public Transform toCut ,FinalCut;
    public Transform to_cut_Arrow;
    public Transform Rotate_Arrow;
    bool click = false;
    float counter =0f;
    float max =5f;

    void Start(){
        counter=max;
    }

    void Update()
    {
        if (click)
        {
            // Enable the MeshRenderer of the second child object after 10 seconds
            StartCoroutine(Delay(5.0f));

           /* counter-=1*Time.deltaTime;
            steps.text = counter.ToString("0")+"\n"+"La vibración de la máquina es buena";
            if(counter<=0){
                counter=0;
            }*/
           
        }


    }


    public void shapeObject()
    {
        // doorAudio.Play();
        if (click == false)
        {

            click = true;
        }
    }
    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
         
        /*
        MeshRenderer renderer1 = transform.GetChild(0).GetComponent<MeshRenderer>();
        renderer1.

        MeshRenderer renderer = transform.GetChild(1).GetComponent<MeshRenderer>();
        renderer.enabled = true;*/
        toCut.gameObject.SetActive(false);
        FinalCut.gameObject.SetActive(true);

    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject == toCut.gameObject)
         {
            steps.text = "Step 3"+"\n\n"+"Click the button on the panel to change the type of blade";
            toCut.SetParent(transform);
            to_cut_Arrow.gameObject.SetActive(false);
            Rotate_Arrow.gameObject.SetActive(true);
         }
    }
}
