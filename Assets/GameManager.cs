using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _loseBar;
    [SerializeField] private int _playerLife = 3;
   
    public TextMeshProUGUI _life;
    public void Start()
    {
        _loseBar.SetActive(false);
    }

    void OnEnable()
    {
        PlayerController.OnEnemyCollision += RestLife;
    }
    void OnDisable()
    {
        PlayerController.OnEnemyCollision -= RestLife;
    }
    void Life()
    {
       
        _life.text = " life: " + _playerLife;
        if (_playerLife <= 0)
        {
            _loseBar.SetActive(true);

        }
    }
    public void RestLife()
    {
        if (_playerLife > 0)
        {
            _playerLife--;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        Life();
    }
}
