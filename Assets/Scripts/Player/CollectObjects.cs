using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectObjects : MonoBehaviour
{
    [Header("Events")]
    [Space]

    public UnityEvent OnPickUpKiwiEvent;

    public UnityEvent OnPickUpBananasEvent;

    public UnityEvent OnPickUpPineappleEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AbilityToShoot")
        {
            Destroy(collision.gameObject);
            OnPickUpKiwiEvent.Invoke();
        }
        if (collision.gameObject.tag == "AbilityToDJump")
        {
            Destroy(collision.gameObject);
            OnPickUpBananasEvent.Invoke();
        }
        if (collision.gameObject.tag == "AbilityToDash")
        {
            Destroy(collision.gameObject);
            OnPickUpPineappleEvent.Invoke();
        }
    }
}
