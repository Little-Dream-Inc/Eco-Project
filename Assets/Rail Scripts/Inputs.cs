using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinInput : MonoBehaviour
{
    Cart currentCart;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
                if(hit.collider.GetComponent<Cart>()) // ==null?
                {
                    currentCart = hit.collider.GetComponent<Cart>();
                    startPos = currentCart.gameObject.transform.position;
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            currentCart = null;
        }

        if(Input.GetMouseButton(0) && currentCart != null)
        {
            currentCart.Move(Camera.main.ScreenToWorldPoint(Input.mousePosition), startPos);
        }
    }
}
