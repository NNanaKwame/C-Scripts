using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rgbd;
    private Animator anime;
    [SerializeField] private AudioSource deathSound;
    //private int Health = 101;
    //[SerializeField] private Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();        
    }

private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.CompareTag("Trap"))
        {
            deathSound.Play();
            Die();
        }
}

private void Die () {
        anime.SetTrigger("Death");
        rgbd.bodyType = RigidbodyType2D.Static;
}

private void Reload () {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
}
}
