using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public AudioSource audio;
    public Animation anim;
    public float speed = 12;
    bool isMoving = true; 
    Vector3 old_pos;
    // Update is called once per frame

    private void Start()
    {
        old_pos.x = 100;

    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        /*
        if (Input.GetKey("w"))
        {
            if(isMoving == false)
            {
                anim.enabled = true;
                anim.wrapMode = WrapMode.Loop;

                anim.Play();

            }
            //move background
            isMoving = true;
        }
        else
        {
            audio.Stop();
            
                anim.wrapMode = WrapMode.Once;                

            
            isMoving = false;
        }
        old_pos = transform.localPosition;
        */
    }
}
