using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogicAnimation : MonoBehaviour
{
    [SerializeField] private float velocityMovement;
    [SerializeField] private float velocityRotation;
    [SerializeField] private float maxVisionAngle = 45f; // M�ximo �ngulo de visi�n en grados
    [SerializeField] private float rotationSpeed = 5f;
    private Animator anim;
    private Transform cameraTransform;
    [SerializeField] private float x, y;
    public Transform cameraPos;
    private GameOver gameOverManager;
    void Start()
    {
        anim = GetComponent<Animator>();
        cameraPos = Camera.main.transform;
    }


    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        transform.Translate(0, 0, y * Time.deltaTime * velocityMovement);

        // Rotaci�n manual del personaje si se mueve lateralmente
        if (x != 0)
        {
            transform.Rotate(0, x * Time.deltaTime * velocityRotation, 0);
        }

        // Ajustar rotaci�n autom�tica si la c�mara est� fuera del rango de visi�n
        RotateTowardsCameraIfOutOfRange();


        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }

    private void RotateTowardsCameraIfOutOfRange()
    {

        Vector3 cameraForward = cameraPos.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        // Direcci�n hacia la que est� mirando el personaje
        Vector3 playerForward = transform.forward;

        // Calculamos el �ngulo entre la c�mara y el personaje
        float angle = Vector3.Angle(playerForward, cameraForward);

        // Si el �ngulo es mayor que el rango permitido, rotamos al personaje hacia la c�mara
        if (angle > maxVisionAngle)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
   
}
