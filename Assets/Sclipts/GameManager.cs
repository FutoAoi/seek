using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] Slider _bgmSlider;
    [SerializeField] Slider _seSlider;
    [SerializeField] Slider _sensSlider;
    [SerializeField] TMP_Text _bgmText;
    [SerializeField] TMP_Text _seText;
    [SerializeField] TMP_Text _sensText;
    [SerializeField] float _timeUp;
    [SerializeField] GameObject _optionPanel;

    bool _inOption = false;

    float _time;

    float _bgmVolume;
    float _seVolume;
    float _sens;

    public float Sens => _sens;
    public float BgmVolume => _bgmVolume;
    public float SeVolume => _seVolume;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
        AudioManager.instance.StartBgm(Bgms.Title);
    }
    void Update()
    {
        if(_bgmSlider.value != _bgmVolume)
        {
            _bgmVolume = _bgmSlider.value;
            _bgmText.text = _bgmVolume.ToString("0.0");
            SetBgmSe();
        }
        if(_seSlider.value != _seVolume)
        {
            _seVolume = _seSlider.value;
            _seText.text = _seVolume.ToString("0.0");
            SetBgmSe();
        }
        if(_sensSlider.value != _sens)
        {
            _sens = _sensSlider.value;
            _sensText.text = _sens.ToString("0.0");
        }
    }
    public void OpenOption()
    {
        _inOption = !_inOption;
        _optionPanel.SetActive(_inOption);
    }
    void SetBgmSe()
    {
        if (AudioManager.instance._bgmAudioSource.volume != GameManager.Instance.BgmVolume)
        {
            AudioManager.instance._bgmAudioSource.volume = GameManager.Instance.BgmVolume;
        }
        for (int i = 0; i < AudioManager.instance._seAudioSource.Length; i++)
        {
            if (AudioManager.instance._seAudioSource[i].volume != GameManager.Instance.SeVolume)
            {
                AudioManager.instance._seAudioSource[i].volume = GameManager.Instance.SeVolume;
            }
        }
    }
}
