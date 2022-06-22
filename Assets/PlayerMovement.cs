using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public int skor;
    public Text scoreText;
    private bool isDead;
    public GameObject deadPanel;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // oyun başlatma
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //ekrana tıklandığında yapılacaklar
        if(Input.GetMouseButtonDown(0))
        {
            //zıplama sesini çal
            AudioManager.PlaySound("jump");
            //kuşu havaya doğru eğ
            transform.rotation = Quaternion.Euler(0, 0, 35);
            //kuşu yukarı çıkar
            rb.velocity = new Vector2(0, Time.fixedDeltaTime * speed);
        }

        //kuş aşağı doğru iniyorsa, kuşu düz yap
        if (rb.velocity.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //kuş öldüğünde olacaklar
        if (isDead)
        {
            //bir kereliğine ölüm sesini çal
            if(Time.timeScale != 0)
                AudioManager.PlaySound("die");
            
            //ölüm ekranını aktifleştir
            deadPanel.SetActive(true);
            //kuşu 90 derece aşşağı eğ
            transform.rotation = Quaternion.Euler(0, 0, -90);

            //kuş yere çarpana kadar yere düşür
            if(transform.position.y > -3)
                transform.position += Vector3.down * 0.02f;
            //oyunu durdur
            Time.timeScale = 0;

            //ekrana tıklandığında oyunu yeniden başlat
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //karakter borunun içinden geçince olacaklar
        if(collision.gameObject.tag == "skor")
        {
            AudioManager.PlaySound("point");
            skor++;
            scoreText.text = skor.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //borulara ya da yere çarptığında olacaklar
        AudioManager.PlaySound("hit");
        isDead = true;
        
    }
}
