using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_script : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    public Sprite activeSprite;
    public Sprite inactiveSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = inactiveSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            spriteRenderer.sprite = activeSprite;
        }
    }
}
