using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectObjects : MonoBehaviour
{

    public GameObject HintSpace;
   
    [Header("Events")]
    [Space]

    public UnityEvent OnPickUpKiwiEvent;

    public UnityEvent OnPickUpBananasEvent;

    public UnityEvent OnPickUpPineappleEvent;

    public UnityEvent OnFinishEnterEvent;
    private void Awake()
    {
        HintSpace = GameObject.Find("Canvas");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AbilityToShoot")
        {
            Destroy(collision.gameObject);
            OnPickUpKiwiEvent.Invoke();
            HintSpace.SendMessage("GetHint", "Click \"V\" to Shoot");
        }
        if (collision.gameObject.tag == "AbilityToDJump")
        {
            Destroy(collision.gameObject);
            OnPickUpBananasEvent.Invoke();
            HintSpace.SendMessage("GetHint", "Click \"Z\" to DoubleJump");
        }
        if (collision.gameObject.tag == "AbilityToDash")
        {
            Destroy(collision.gameObject);
            OnPickUpPineappleEvent.Invoke();
            HintSpace.SendMessage("GetHint", "Click \"C\" to Dash");
        }
        if(collision.gameObject.tag == "Finish")
        {
            OnFinishEnterEvent.Invoke();
        }
    }
}
