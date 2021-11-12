using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Egg : MonoBehaviour
{
    public GameObject letterObject;
    private TMP_Text textComponent;
    private void Start()
    {
        textComponent = letterObject.GetComponent<TMP_Text>();
        textComponent.text = LetterGenerator.generateLetter();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FryingPan"))
        {
            WordManager.letterCollected(textComponent.text);
            Destroy(gameObject);
            
        }
    }
}
