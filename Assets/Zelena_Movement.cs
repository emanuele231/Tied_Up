using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zelena_Movement : MonoBehaviour
{

   private Rigidbody2D zelena;
   private bool isJumping = false;
   private float dirX = 0f; 
 private Animator anim; //variabile per animazione
   /* int wholeNumber = 16;
    float decimalNumber = 4.54f;
    string text = "this->";
    bool boolean = false;*/
    // Start is called before the first frame update
   private void Start()
    {
       zelena =  GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       //int jumpD = 0;
    }

    // Update is called once per frame
    private void Update()
    {
         
        dirX = Input.GetAxisRaw("HorizontalZ");
        zelena.velocity = new Vector2(dirX * 3.5f, zelena.velocity.y);
       if (Input.GetButtonDown("JumpZ") && !isJumping)
       {
        
      zelena.velocity = new Vector3(zelena.velocity.x, 5.5f);
      isJumping=true;
      } 
       UpdateAnimationUpdate();

       
    }
    private void UpdateAnimationUpdate(){ //metodo che controlla le animazioni di durdust 

if (dirX > 0f)
      {
          anim.SetBool("destra", true);
      }
      else if (dirX < 0f)
      {
          anim.SetBool("sinistra", true);
      }
      else {
          anim.SetBool("destra", false); 
          anim.SetBool("sinistra", false);
      }
}
      private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Terrain")){
            isJumping = false;
        }
    }
}

