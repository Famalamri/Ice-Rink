using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Animator animator;
    private string batAnim;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && animator != null)
        {
            batAnim = "batAttack";

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(batAnim))
            {
                animator.Play(batAnim);
            }
        }
    }

    private void Attack()
    {
        
    }
}
