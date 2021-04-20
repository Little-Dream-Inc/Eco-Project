using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinsInput : MonoBehaviour
{
    Vector2 startPos;
    GameObject currentBin;
    BinManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<BinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Bin"))
            {
                startPos = Input.mousePosition;
                currentBin = hit.collider.gameObject;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            var pos = Input.mousePosition;

            int direction = (startPos.x <= pos.x) ? 1 : -1;
            manager.Reorder(currentBin.GetComponent<Bin>(), direction);
        }
    }
}
