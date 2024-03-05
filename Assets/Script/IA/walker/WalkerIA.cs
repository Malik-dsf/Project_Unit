using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerIA : MonoBehaviour
{
    public float detectionRange = 10f;
    public float moveSpeed = 5f;

    [SerializeField]
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return; //voie si ya un joueur

        // Calculer la distance entre le j et lui
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // regarde si le j est a distance
        if (distanceToPlayer < detectionRange)
        {
            // Créer un vecteur directionnel vers le joueur
            Vector3 direction = (player.position - transform.position).normalized;

            // Lancer un rayon pour détecter les obstacles entre l'ennemi et le joueur
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, detectionRange))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    // Si le joueur est en ligne de vue, poursuivre
                    transform.Translate(direction * moveSpeed * Time.deltaTime);
                }
                // Si un obstacle est rencontré, ne pas poursuivre
            }
        }
    }



}
