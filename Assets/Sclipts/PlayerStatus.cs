using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [Header("HPê›íË")]
    [SerializeField] int _maxHp = 100;
    [SerializeField] Image _hpGauge;
    
    int _currentHp;
    void Start()
    {
        _currentHp = _maxHp;
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
        SceneManager.LoadScene(0);
    }
}
