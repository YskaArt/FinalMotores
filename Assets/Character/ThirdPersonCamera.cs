using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; 
    public float distanceFromTarget = 5.0f; // Distancia de la c�mara al jugador
    public float heightOffset = 2.0f; // Altura de la c�mara respecto al jugador
    public float rotationSpeed = 5.0f; // Velocidad de rotaci�n de la c�mara
    public float followSpeed = 10.0f; // Suavidad del seguimiento de la c�mara

    private float yaw; // Rotaci�n horizontal 
    private float pitch; // Rotaci�n vertical 
    private bool cursorVisible = false; 

    void Start()
    {
        // Inicializamos la c�mara detr�s del jugador
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
            // Obtiene la entrada del mouse para rotar la c�mara
            yaw += Input.GetAxis("Mouse X") * rotationSpeed;
            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
            pitch = Mathf.Clamp(pitch, -30f, 60f); // Limita el �ngulo vertical

            // Calculam la rotaci�n y posici�n de la c�mara
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
            Vector3 offset = new Vector3(0, heightOffset, -distanceFromTarget);
            Vector3 targetPosition = target.position + rotation * offset;

            // Interpolamos la posici�n de la c�mara para que el movimiento sea suave
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            transform.LookAt(target.position + Vector3.up * heightOffset); // Hacemos que la c�mara mire al jugador
        }
    }

    // M�todo para cambiar el estado del cursor
    private void SetCursorState(bool visible)
    {
        Cursor.visible = visible; 
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked; 
    }
}
