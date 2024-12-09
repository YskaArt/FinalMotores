using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float TempoForDestroy = 10f; // Tiempo en segundos antes de eliminar el objeto
    public GameObject bloodParticlesPrefab;

    void Start()
    {
        // Llama a la funci�n Eliminar tras el intervalo de tiempo especificado
        Destroy(gameObject, TempoForDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            // Instancia las part�culas de sangre en el punto de colisi�n.
            Instantiate(bloodParticlesPrefab, collision.contacts[0].point, Quaternion.identity);

           
        }
    }


}
