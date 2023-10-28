using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool mulaiGame;
    public GameObject textMulai;
    public static int jumlahCoin;
    public Text coinText;

    private void Awake () 
    {
        instance = this;
    }
    void Start()
    {
        gameOver = false;  
        Time.timeScale = 1;  
        mulaiGame = false;
        jumlahCoin = 0;
    }

    void Update()
    {
        if(gameOver) 
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);    
        }
        coinText.text = "Coin: "+jumlahCoin;
        if(SwipeController.tap) 
        {
            mulaiGame = true;
            Destroy(textMulai);
        }
    }
}
