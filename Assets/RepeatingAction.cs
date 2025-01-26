using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepeatingAction : MonoBehaviour
{
    public UnityEvent action;
    public float cooldown;
    float timeToNextAction;


    // Start is called before the first frame update
    void Awake()
    {
        timeToNextAction = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextAction -= Time.deltaTime;
        if (timeToNextAction <= 0)
        {
            action.Invoke();
            timeToNextAction += cooldown;
        }
    }
}
