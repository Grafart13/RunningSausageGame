using UnityEngine;
using System.Collections;

public class EnemyMovements : MonoBehaviour {

    Transform player; // referencja do pozycji playera
    //PlayerHealth playerHealth; // referencja do zmiennej trzymającej zdrowie Parowki
    NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetCOmponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(player.position);	
	}
}
