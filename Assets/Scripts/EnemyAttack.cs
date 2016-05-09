using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange; // czy Parowka weszla w kolidera wroga
    float timer;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true; // Parowka weszla w kolidera wroga!
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player )
        {
            playerInRange = false; // Parowki juz nie ma w zasiegu kolidera wroga!
            anim.ResetTrigger("Attack");
        }
    }

	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        
        if ((timer>=timeBetweenAttacks) && (playerInRange))
        {
            Attack(); // ATAKUJ!
        }

        if (playerHealth.currentHealth <=0)
        {
            anim.SetTrigger("PlayerDead");
        }
	}

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            anim.SetTrigger("Attack");
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
