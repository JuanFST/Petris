using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChange : MonoBehaviour
{
    private string newTag;

    private void Start()
    {
        gameObject.tag = "Animalito1";
        newTag = "Animalito2";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso" | collision.gameObject.tag == "Animalito1")
        {
            gameObject.tag = newTag;
            collision.gameObject.tag = newTag;
            Debug.Log("Cambie el tag");
        }
    }

}
