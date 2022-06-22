using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip jump;
    public static AudioClip hit;
    public static AudioClip point;
    public static AudioClip die;
    static AudioSource audioSrc;
    void Start()
    {
        //sesleri yükle
        jump = Resources.Load<AudioClip>("wing");
        hit = Resources.Load<AudioClip>("hit");
        point = Resources.Load<AudioClip>("point");
        die = Resources.Load<AudioClip>("die");

        audioSrc = GetComponent<AudioSource>();
    }

    
    //oynatılacak seslere başka scriptten erişme
    public static void PlaySound(string _name)
    {
        switch(_name)
        {
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "point":
                audioSrc.PlayOneShot(point);
                break;
            case "die":
                audioSrc.PlayOneShot(die);
                break;

        }
    }

}
