using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab; // Prefab del proyectil
    [SerializeField] private Transform shootPoint;        // Punto desde donde se dispara el proyectil
    [SerializeField] private float fireRate = 0.5f;       // Cadencia de disparo (segundos entre disparos)
    [SerializeField] private LayerMask targetLayer;       // Capas donde puede apuntar el disparo
    private float nextFireTime = 0f;                      // Tiempo mínimo para el siguiente disparo

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            // Actualizar el tiempo del siguiente disparo
            nextFireTime = Time.time + fireRate;

            // Activar la animación de disparo
            if (anim != null)
            {
                anim.SetTrigger("shoot");
            }
        }
    }

    
    public void ShootProjectile()
    {
        if (projectilePrefab == null || shootPoint == null)
            return;

        // Calcular la dirección hacia el puntero
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, targetLayer))
        {
            Vector3 shootDirection = (hit.point - shootPoint.position).normalized;

            // Instanciar el proyectil
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            projectile.transform.forward = shootDirection;

            // Asignar velocidad al proyectil
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = shootDirection * 40f; // Ajusta la velocidad según sea necesario
            }
        }
    }
}