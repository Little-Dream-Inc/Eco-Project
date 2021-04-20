using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public GarbageType type; //TODO make read-only

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("triggered!!");
        if (collision.gameObject.CompareTag("Garbage"))
        {
            bool isCorrect = false;
            var garbageType = collision.gameObject.GetComponent<Garbage>().type;
            if (garbageType == type)
            {
                isCorrect = true;
            }
            GarbageFeedback(isCorrect);
            Destroy(collision.gameObject, .2f);
        }
    }

    void GarbageFeedback(bool isCorrect)
    {
        if(isCorrect)
        {
            print("Great");
        }
        else
        {
            print("Wrong!");
        }
    }
}