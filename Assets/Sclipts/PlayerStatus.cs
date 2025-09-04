using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [Header("HPê›íË")]
    [SerializeField] int _maxHp = 100;
    [SerializeField] Image _hpGauge;
    [SerializeField] TMP_Text _Timer;
    
    int _currentHp;
    float _timar;
    void Start()
    {
        _currentHp = _maxHp;
        _timar = GameManager.Instance.TimeUp;
    }
    private void Update()
    {
        _timar -= Time.deltaTime;
        _Timer.text = _timar.ToString("000");
        if(_timar < 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
        _hpGauge.fillAmount = (float)_currentHp / _maxHp;
        if (_currentHp < 0)
        {
            Die();
        }
    }
    public void Heal(int _heal)
    {
        _currentHp += _heal;
        _currentHp = Mathf.Min(_currentHp,_maxHp);
    }
    private void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioManager.instance.StartBgm(Bgms.GameOver);
        SceneManager.LoadScene(3);
    }
}
