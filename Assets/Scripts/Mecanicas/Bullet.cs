using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float TempoForDestroy = 10f; // Tiempo en segundos antes de eliminar el objeto

   
    void Start()
    {
        // Llama a la función Eliminar tras el intervalo de tiempo especificado
        Destroy(gameObject, TempoForDestroy);
    }
   
}
