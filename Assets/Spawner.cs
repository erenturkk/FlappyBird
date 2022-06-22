using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipe;
    public float timer;
    private float baseTimer;
    void Start()
    {
        //oyun başladığında bir adet boru spawn et
        GameObject go = Instantiate(pipe, transform);
        go.transform.position = new Vector2(go.transform.position.x, Random.Range(-0.75f, 1.60f));

        //zamanlayacıyı ayarla
        baseTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        //eğer zamanlayacı 0dan kücükse boruyu spawn et
        if(timer < 0)
        {
            GameObject go = Instantiate(pipe, transform);
            go.transform.position = new Vector2(go.transform.position.x, Random.Range(-0.75f, 1.60f));
            timer = baseTimer;

        }

    }
}
