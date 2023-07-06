using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.tag == "Animalito2")
         {
             gameManager.Win();
         }
     }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Animalito2")
        {
            gameManager.Win();
        }
    }
    

}
