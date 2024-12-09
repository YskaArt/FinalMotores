using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Objetivo a seguir (en este caso el jugador)
    public float distanceFromTarget = 5.0f; // Distancia de la camara al jugador
    public float heightOffset = 2.0f; // Altura de la cámara respecto al jugador
    public float rotationSpeed = 5.0f; // Velocidad de rotación con el ratón
    public float followSpeed = 10.0f; 

    public LayerMask collisionMask; // Capas con las que la cámara puede colisionar (esto para evitar que traspase Paredes por ejemplo) 
    public float collisionRadius = 0.3f; // Radio del SphereCast para detección de colisiones

    private float yaw;
    private float pitch;

    void Start()
    {
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Rotación basada en el ratón
        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, -30f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Posición deseada de la cámara
        Vector3 offset = new Vector3(0, heightOffset, -distanceFromTarget);
        Vector3 desiredPosition = target.position + rotation * offset;

        Vector3 direction = desiredPosition - (target.position + Vector3.up * heightOffset);
        float desiredDistance = direction.magnitude;
        RaycastHit hit;

        if (Physics.SphereCast(target.position + Vector3.up * heightOffset, collisionRadius, direction.normalized, out hit, desiredDistance, collisionMask))
        {
            // Si hay una colisión, ajustar la distancia de la cámara
            desiredPosition = (target.position + Vector3.up * heightOffset) + direction.normalized * (hit.distance - collisionRadius);
        }


        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Asegurar que la cámara siempre mire al objetivo
        transform.LookAt(target.position + Vector3.up * heightOffset);
    }
}
