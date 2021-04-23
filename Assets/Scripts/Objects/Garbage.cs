using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public GarbageType type;
    [SerializeField] float speed = 5;
    [SerializeField] int scorePrice;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public int GetScorePrice()
    {
        return scorePrice;
    }
}
