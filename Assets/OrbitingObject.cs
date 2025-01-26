using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingObject : MonoBehaviour
{
    public float orbitSpeed;
    public bool tidalLock;

    private Quaternion originalRotation;

    private void Awake()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        transform.RotateAround(GameManager.Instance.bubble.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);

        if(tidalLock)
        {
            //Face the bubble
            Vector3 direction = GameManager.Instance.bubble.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        {
            transform.rotation = originalRotation;
        }
    }
}
