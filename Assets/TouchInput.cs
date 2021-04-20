using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    Vector2 startPos;
    GameObject currentBin;
    BinManager manager;
    
    
    public ParticleSystem demoParts;

    void Start()
    {
        manager = FindObjectOfType<BinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

                if (hit.collider != null && hit.collider.CompareTag("Bin"))
                {
                    startPos = touch.position;
                    currentBin = hit.collider.gameObject;
                    print(currentBin.gameObject.name);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                var pos = touch.position;

                int direction = (startPos.x <= pos.x) ? 1 : -1;
                manager.Reorder(currentBin.GetComponent<Bin>(), direction);
            }
        }
    }
    
}
