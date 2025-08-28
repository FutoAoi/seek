using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [Header("HP設定")]
    [SerializeField] int _maxHp = 100;
    
    [Header("スタミナ設定")]
    [SerializeField] int _maxSutamina = 100;

    int _currentHp,_currentSutamina;
    void Start()
    {
        _currentHp = _maxHp;
        _currentSutamina = _maxSutamina;
    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
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
