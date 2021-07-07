using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public GameObject damageNumber;

    private PlayerStats playerStats;
    private int modifiedDamage;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        modifiedDamage = damageToGive - playerStats.currentDefense;
        if (modifiedDamage <= 1)
        {
            modifiedDamage = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(modifiedDamage);
            var clone = (GameObject)Instantiate(damageNumber, collision.gameObject.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damage = modifiedDamage;
        }
    }
}
