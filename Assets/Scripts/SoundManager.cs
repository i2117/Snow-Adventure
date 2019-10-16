using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    public float musicVolume = 0.3F;
    public AudioSource[] _MusicSources;

    public AudioClip
        buttonSound,
        bonusCollectedSound,
        lostSound;

    bool _isMain = false;

    void Awake()
    {
        if (instance != null && !_isMain)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            _isMain = true;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySound (AudioClip audioClip, float delay = 0)
    {
        StartCoroutine(Playing(audioClip, delay)); 
    }

    IEnumerator Playing (AudioClip audioClip, float delay = 0)
    {
        yield return new WaitForSeconds(delay);

        var go = new GameObject().AddComponent<AudioSource>();
        DontDestroyOnLoad(go);
        var aS = go.GetComponent<AudioSource>();
        aS.clip = audioClip;
        aS.Play();

        Destroy(go, audioClip.length * 1.1f);
    }
}
