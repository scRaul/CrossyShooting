using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip ruffle,playerMove, enemyMove, gunShot, gunReload,gunEmpty,hit;
    GameObject source;
    private void Awake()
    {
        source = transform.gameObject;
        ruffle = Resources.Load<AudioClip>("ruffle");
        playerMove = Resources.Load<AudioClip>("playerMove");
        enemyMove = Resources.Load<AudioClip>("EnemyMove");
        gunShot = Resources.Load<AudioClip>("singleShot");
        gunReload = Resources.Load<AudioClip>("reload");
        gunEmpty = Resources.Load<AudioClip>("empty");
        hit = Resources.Load<AudioClip>("hit");

    }
    public void PlaySound(string sound)
    {
        if(sound == "ruffle")
            AudioSource.PlayClipAtPoint(ruffle, source.transform.position, 1f);
        if (sound ==  "jump")
        { 
          if(source.CompareTag("Player"))
            AudioSource.PlayClipAtPoint(playerMove, source.transform.position, .6f);
           if(source.CompareTag("Enemy"))
            AudioSource.PlayClipAtPoint(enemyMove, source.transform.position, 1f);
        }
        if(sound == "shot")
            AudioSource.PlayClipAtPoint(gunShot,source.transform.position, .7f);
        if (sound == "reload")
            AudioSource.PlayClipAtPoint(gunReload, source.transform.position, 1f);
        if(sound == "empty")
            AudioSource.PlayClipAtPoint(gunEmpty, source.transform.position, 1f);
        if(sound == "hit")
            AudioSource.PlayClipAtPoint(hit, source.transform.position, 1f);
    }
}
