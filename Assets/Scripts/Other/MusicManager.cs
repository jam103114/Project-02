using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip _menuClip = null;
    [SerializeField] AudioClip _dungeonClip = null;
    [SerializeField] AudioSource _audioSource = null;
    public int musicSelect = 1;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource.clip = _menuClip;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (musicSelect == 1)
        {
            _audioSource.clip = _menuClip;
            _audioSource.Play();
            musicSelect = 0;
        }
        else if (musicSelect == 2)
        {
            _audioSource.clip = _dungeonClip;
            _audioSource.Play();
            musicSelect = 0;
        }
    }
}
