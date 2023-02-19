using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{   
    public int HP = 100;
    public Animator animator;
    public void TakeDamage(int damageAmount){
        HP -= damageAmount;
        if(HP<=0)
        {
            animator.SetTrigger("die");//play death animation
        }
        else
        {
           animator.SetTrigger("damage"); //hit animation
        }
    }
}
