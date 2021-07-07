using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text hpText;
    public Text levelText;
    public PlayerHealthManager playerHealth;
    private PlayerStats playerStats;

    private static bool uiExists;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();

        if (!uiExists)
        {
            uiExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        hpText.text = "HP: " + healthBar.value + "/" + healthBar.maxValue;
        levelText.text = "Level: " + playerStats.currentLevel;
    } 
}
