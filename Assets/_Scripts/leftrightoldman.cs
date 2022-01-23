using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class leftrightoldman : MonoBehaviour
{

    public float moveSpeed;
    public Animator animator;
    public AudioSource oldmanwalking;
   // bool isMoving = false;

    //bool facingRight=0;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.5f;

        oldmanwalking = GetComponent<AudioSource>();
    }// Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);

        Vector3 characterScale = transform.localScale;


       

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
            animator.SetFloat("Horizontal", 1);
            if(!oldmanwalking.isPlaying)
            {
                oldmanwalking.Play();
            }
           
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
            animator.SetFloat("Horizontal", 1);
            if (!oldmanwalking.isPlaying)
            {
                oldmanwalking.Play();
            }

        }
        else
        {
            animator.SetFloat("Horizontal", 0);
            if(oldmanwalking.isPlaying)
            {
                oldmanwalking.Pause();
            }
         
        }
        transform.localScale = characterScale;

        

        

    }
}
