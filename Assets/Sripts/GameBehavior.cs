using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


using UnityEngine.SceneManagement;
public class GameBehavior : MonoBehaviour
{

    public int MaxItems = 4;
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;
   
    private int _itemsCollected = 0;
    
    private int _playerHP = 10;


    public Button WinButton;
    

    void Start()
    {
        // Initialize the text fields on start
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
    }

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            ItemText.text = "Items Collected: " + Items;

            if (_itemsCollected >= MaxItems)
            {
                ProgressText.text = "You found all the items!";

                WinButton.gameObject.SetActive(true);

                Time.timeScale = 0f;
            }
            else
            {
                ProgressText.text = "Item found, only " + (MaxItems - _itemsCollected) + " more to go!";
            }

        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Health: " + HP;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

  
}
