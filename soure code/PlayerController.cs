using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 arah;
    public float kecepatanPlayer;
    public float kecepatanMax;
    private int jalurTengah = 1;
    public float lebarJalur = 4;
    public float tinggiLompatan;
    public float gravity = -20;
    public Animator animator;
    public ParticleController particleController;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        if(!PlayerManager.mulaiGame)
            return;

        if(kecepatanPlayer < kecepatanMax)
            kecepatanPlayer += 0.1f * Time.deltaTime;

        animator.SetBool("isGameStarted", true);
        arah.z = kecepatanPlayer;
        
        arah.y += gravity * Time.deltaTime;
        animator.SetBool("isGrounded", true);
        particleController.MovementPlay();
        
        if(controller.isGrounded) 
        {
            if(SwipeController.swipeAtas)
                {
                    Lompat();
                    animator.SetBool("isGrounded", false);
                }
        }

        if(SwipeController.swipeKanan)
        {
            jalurTengah++;
            if(jalurTengah == 3) 
                jalurTengah = 2;  
        }

        if(SwipeController.swipeKiri) 
        {
            jalurTengah--;
            if(jalurTengah == -1) 
                jalurTengah = 0;     
        }

        Vector3 targetPosisi = transform.position.z * transform.forward + transform.position.y * transform.up;
    
        if(jalurTengah == 0) 
        {
            targetPosisi += Vector3.left * lebarJalur;
        }

        else if(jalurTengah == 2) 
        {
            targetPosisi += Vector3.right * lebarJalur;    
        }

        //transform.position = Vector3.Lerp(transform.position, targetPosisi, 80f );
        if(transform.position != targetPosisi)
        {
        Vector3 diff = targetPosisi - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
        } 
        controller.Move(arah * Time.deltaTime);

    }


    private void Lompat () 
    {
        arah.y = tinggiLompatan;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
       if(hit.transform.tag == "Obstacle") 
       {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
       } 
    }
}
