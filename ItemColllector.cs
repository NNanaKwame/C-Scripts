using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator anime;
    private int Token = 0;
    [SerializeField] private Text tokenText;
    [SerializeField] private AudioSource collectSound;

    private void Start()
    {
    anime = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Token"))
        {
            collectSound.Play();
            //anime.SetBool("Collect",true);
            Destroy(collision.gameObject);
            Token++;
            Debug.Log("Token :" + Token);
            tokenText.text = "Token: " + Token;
        }
        
    }
}
