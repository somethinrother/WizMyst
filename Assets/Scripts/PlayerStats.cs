using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExperience;
    public int[] experienceThreshholds;
    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenseLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefense;

    private PlayerHealthManager playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(currentExperience >= experienceThreshholds[currentLevel])
        {
            LevelUp();
        }
    }

    public void AddExperience(int xpGained)
    {
        currentExperience += xpGained;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];
        currentAttack = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];

        playerHealth.playerMaxHealth = currentHP;
        int healthDifference = currentHP - HPLevels[currentLevel - 1];
        playerHealth.playerCurrentHealth += healthDifference;
    }
}
