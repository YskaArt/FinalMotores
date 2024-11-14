using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogicAnimation : MonoBehaviour
{
    [SerializeField] private float velocityMovement;
    [SerializeField] private float velocityRotation;
    private Animator anim;
    [SerializeField] private float x, y;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocityRotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocityMovement);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }
}
