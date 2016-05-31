using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    GameObject player;
    GUIBarScript guiBarScript;
    Animator anim;
    movement playerMovement;
    bool isDead;
    bool damaged;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<movement>();
        currentHealth = startingHealth;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        guiBarScript = player.GetComponent<GUIBarScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
	}

    public void TakeDamage(int amount)
    {
        damaged = true;
        guiBarScript.SetNewValue(guiBarScript.Value - amount/100.0f);
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        playerMovement.enabled = false;
    }

}
