using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public GameObject damageAnimation;
    public Transform hitPoint;
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
        modifiedDamage = damageToGive + playerStats.currentAttack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(modifiedDamage);
            Instantiate(damageAnimation, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, collision.gameObject.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damage = modifiedDamage;
        }
    }
}
