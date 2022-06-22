using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //eğer yer çok ilerideyse geri getir
        if(transform.position.x < -35.59)
        {
            transform.position = new Vector2(34, transform.position.y);
        }

        //her saniye yeri sola doğru belli bir hızla kaydır
        transform.position += Vector3.left * Time.deltaTime * 1.8f;
    }
}
