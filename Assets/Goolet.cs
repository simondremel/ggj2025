using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goolet : MonoBehaviour
{
    public float speed = 8f;
    public float gooAmount;
    public Transform target;
    public bool ignoreBubbleEnter = false;
    public bool ignoreBubbleExit = false;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);   
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // Destroy bullet when it leaves the screen
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Bubble>() != null)
        {
            if (ignoreBubbleEnter) return;
            Bubble bubble = collision.GetComponent<Bubble>();
            bubble.Grow(gooAmount);
            Destroy(gameObject);
        }
        else if (collision.GetComponent<Extractor>() != null)
        {
            Extractor extractor = collision.GetComponent<Extractor>();
            extractor.Collect();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Bubble>() != null)
        {
            if (ignoreBubbleExit) return;
            Bubble bubble = collision.GetComponent<Bubble>();
            bubble.Grow(-1 * gooAmount);
        }
    }
}
