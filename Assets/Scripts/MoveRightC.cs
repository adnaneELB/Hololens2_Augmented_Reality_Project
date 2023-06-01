using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveRightC : MonoBehaviour
{
    public Text steps;
    public Transform rotate_arrow;
    public Transform on_arrow;
    public Transform door_arrow;
    public Transform off_arrow;
    public Transform needle;
    public Transform LeftC;
    public Transform target1;
    public Transform target2;
    bool movingDown;
    bool movingLeft;
    bool movingUP;
    bool movingRight;
    private Vector3 OriginalPos;
    private Animator anim, needleAnim;
    public Transform RightC;
    public ParticleSystem craftingSmoke;
    public ParticleSystem craftingSpark;
    bool call = false;
    bool callback = false;
    public Canvas canvas;
    public TextMeshProUGUI textMeshPro;
    public RawImage rawImage;
    public float countdownTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
        steps.text = "Step 1"+"\n\n"+"Click the button to open the machine door";
        textMeshPro.enabled = false;
        rawImage.enabled = false;
        needleAnim = needle.GetComponent<Animator>();
        movingDown = false;
        movingLeft = false;
        movingUP = false;
        movingRight = false;
        OriginalPos = transform.position;
        anim = LeftC.GetComponent<Animator>();
        canvas.enabled = false;

    }


    public void click()
    {
        if (!call)
        {
            call = true;
        }
    }
    public void clickback()
    {
        if (!callback)
        {
            callback = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*if(ifCounter==true){
            //steps.fontSize=130;
             counter-=1*Time.deltaTime;
            steps.text = counter.ToString("0");
            if(counter<=0){
                counter=0;
                steps.text="now you can open the door";
            }
        }*/

        if (call)
        {   // turn on the screen
            canvas.enabled = true;

            // enable the video video
            textMeshPro.enabled = true;
            rawImage.enabled = true;

            needleAnim.SetBool("turn", true);
            movmment();
        }

        if (callback)
        {   // turn off the screen
            canvas.enabled = false;

            // disable the vibration video
            textMeshPro.enabled = false;
            rawImage.enabled = false;

            needleAnim.SetBool("turn", false);
            back();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

        }

    }
    public void arrow_off()
    {
        on_arrow.gameObject.SetActive(false);
        StartCoroutine(StartCountdown());
         
    }
    private System.Collections.IEnumerator StartCountdown()
    {
        steps.fontSize=150;
        float timer = countdownTime;

        while (timer > 0f)
        {
            yield return null; 

            timer -= Time.deltaTime; 
          
           steps.text = Mathf.CeilToInt(timer).ToString();
        }
         off_arrow.gameObject.SetActive(true);
         steps.fontSize=29;
         steps.text = "Step 6"+"\n\n"+"Stop working the machine by clicking the OFF button on the panel";
      
    }
    public void Rota()
    {
        RightC.Rotate(0, -45, 0);
        rotate_arrow.gameObject.SetActive(false);
        door_arrow.gameObject.SetActive(true);
        steps.text = "Step 4"+"\n\n"+"Click the button again to close the machine door";
    }
    private void movmment()
    {
        // Moves the object forward at two units per second.
        if (call)
        {
            movingDown = true;

        }
        if (movingDown)
        {

            transform.position = Vector3.MoveTowards(transform.position, target1.position, 0.3f * Time.deltaTime);
            if (transform.position == target1.position)
            {
                movingDown = false;
                movingLeft = true;
            }
        }
        if (movingLeft)
        {

            transform.position = Vector3.MoveTowards(transform.position, target2.position, 1 * Time.deltaTime);
            if (transform.position == target2.position)
            {
                movingLeft = false;
                anim.SetBool("turn", true);
                craftingSmoke.Play();
                craftingSpark.Play();
                call = false;
            }
        }
    }

    private void back()
    {
        // Moves the object forward at two units per second.
        if (callback)
        {
            movingRight = true;
            off_arrow.gameObject.SetActive(false);
            steps.text = "Step 7"+"\n\n"+"Now open the door to observe the reshaped piece";
            door_arrow.gameObject.SetActive(true);
        }
        if (movingRight)
        {

            transform.position = Vector3.MoveTowards(transform.position, target1.position, 0.2f * Time.deltaTime);
            anim.SetBool("turn", false);
            craftingSmoke.Stop();
            craftingSpark.Stop();
            if (transform.position == target1.position)
            {
                movingRight = false;
                movingUP = true;
            }
        }
        if (movingUP)
        {

            transform.position = Vector3.MoveTowards(transform.position, OriginalPos, 1 * Time.deltaTime);
            if (transform.position == OriginalPos)
            {
                movingUP = false;
                callback = false;
            }
        }
    }

}
