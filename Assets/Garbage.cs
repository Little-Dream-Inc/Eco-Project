using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public GarbageType type;
    [SerializeField] float speed = 5;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
