using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerderVida : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Animalito") || collision.gameObject.CompareTag("Animalito2"))
        {
            Destroy(collision.gameObject);
        }
        gameManager.removeLife();
       
    }
}
