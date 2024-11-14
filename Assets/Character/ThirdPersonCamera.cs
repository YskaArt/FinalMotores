using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; 
    public float distanceFromTarget = 5.0f; // Distancia de la cámara al jugador
    public float heightOffset = 2.0f; // Altura de la cámara respecto al jugador
    public float rotationSpeed = 5.0f; // Velocidad de rotación de la cámara
    public float followSpeed = 10.0f; // Suavidad del seguimiento de la cámara

    private float yaw; // Rotación horizontal 
    private float pitch; // Rotación vertical 
    private bool cursorVisible = false; 

    void Start()
    {
        // Inicializamos la cámara detrás del jugador
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
        SetCursorState(false); // Ocultamos el cursor al inicio
    }

    void LateUpdate()
    {
        // Activar o desactivar el cursor cuando se presiona Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorVisible = !cursorVisible; // Cambiar el estado del cursor
            SetCursorState(cursorVisible);
        }

        if (!cursorVisible)
        {
            // Obtiene la entrada del mouse para rotar la cámara
            yaw += Input.GetAxis("Mouse X") * rotationSpeed;
            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
            pitch = Mathf.Clamp(pitch, -30f, 60f); // Limita el ángulo vertical

            // Calculam la rotación y posición de la cámara
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
            Vector3 offset = new Vector3(0, heightOffset, -distanceFromTarget);
            Vector3 targetPosition = target.position + rotation * offset;

            // Interpolamos la posición de la cámara para que el movimiento sea suave
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            transform.LookAt(target.position + Vector3.up * heightOffset); // Hacemos que la cámara mire al jugador
        }
    }

    // Método para cambiar el estado del cursor
    private void SetCursorState(bool visible)
    {
        Cursor.visible = visible; 
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked; 
    }
}
