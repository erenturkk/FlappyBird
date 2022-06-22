using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed;
    void Start()
    {
        //borular spawn olduktan 7 sonra onları yok et
        //böylece oyunda kasma olmaz.
        Destroy(gameObject, 7);
    }

    // Update is called once per frame
    void Update()
    {
        // boruları her saniye belli hızla sola kaydır.
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
