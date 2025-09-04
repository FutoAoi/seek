using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Bgms
{
    None,
    Title,
    InGame
}
public enum Ses
{
    Get,
    Result,
    Money,
    See
}
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] public AudioSource _bgmAudioSource;
    [SerializeField] public AudioSource[] _seAudioSource;
    [SerializeField] AudioClip _inTitleBgm;
    [SerializeField] AudioClip _inGameBgm;
    [SerializeField] AudioClip _getSe;
    [SerializeField] AudioClip _ResultSe;
    [SerializeField] AudioClip _MoneySe;
    [SerializeField] AudioClip _seeSe;

    int _count = 0;

    private void Awake()
    {
        if (instance != null && instance != this )
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        for(int i = 0;  i < _seAudioSource.Length; i++)
        {
            if(!_seAudioSource[i].isPlaying)
            {
                _seAudioSource[i].clip = null;
            }
        }
    }

    public void StartBgm(Bgms bgms)
    {
        _bgmAudioSource.Stop();
        switch(bgms)
        {
            case Bgms.None:
                _bgmAudioSource.Stop(); return;
            case Bgms.Title:
                _bgmAudioSource.clip = _inTitleBgm; break;
            case Bgms.InGame:
                _bgmAudioSource.clip = _inGameBgm; break;
        }
        _bgmAudioSource.Play();
    }

    public void PlaySe(Ses ses)
    {
        switch(ses)
        {
            case Ses.Result:
                _seAudioSource[_count].clip = _ResultSe; break;
            case Ses.Get:
                _seAudioSource[_count].clip = _getSe; break;
            case Ses.Money:
                _seAudioSource[_count].clip = _MoneySe; break;
            case Ses.See:
                _seAudioSource[_count].clip = _seeSe; break;
        }
        _seAudioSource[_count].Play();
        _count++;
        if(_count == _seAudioSource.Length)
        {
            _count = 0;
        }
    }
}
