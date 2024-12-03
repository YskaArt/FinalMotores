using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogicAnimation : MonoBehaviour
{
    [SerializeField] private float velocityMovement;
    [SerializeField] private float velocityRotation;
    [SerializeField] private float maxVisionAngle = 45f; // Máximo ángulo de visión en grados
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

        // Rotación manual del personaje si se mueve lateralmente
        if (x != 0)
        {
            transform.Rotate(0, x * Time.deltaTime * velocityRotation, 0);
        }

        // Ajustar rotación automática si la cámara está fuera del rango de visión
        RotateTowardsCameraIfOutOfRange();


        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }

    private void RotateTowardsCameraIfOutOfRange()
    {

        Vector3 cameraForward = cameraPos.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        // Dirección hacia la que está mirando el personaje
        Vector3 playerForward = transform.forward;

        // Calculamos el ángulo entre la cámara y el personaje
        float angle = Vector3.Angle(playerForward, cameraForward);

        // Si el ángulo es mayor que el rango permitido, rotamos al personaje hacia la cámara
        if (angle > maxVisionAngle)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
   
}
