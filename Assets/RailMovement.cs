using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RailMovement : MonoBehaviour
{
    [SerializeField] public Vector2 railStart;
    [SerializeField] public Vector2 railEnd;
    [SerializeField] float initialPoint;
    [SerializeField] Color color;

    Vector2 medianPoint;

    public float pathLength;

    // Start is called before the first frame update
    void Start()
    {
        pathLength = Vector2.Distance(railStart, railEnd);
        transform.position = railStart;
        MoveOnRail(0.5f);
        medianPoint = transform.position; //TODO calculate median point without moving an object
        MoveOnRail(initialPoint);
        Debug.DrawLine(railEnd, railStart, color, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveOnRail(float translation) 
    {
        Debug.Log(translation);
        if(translation > 1 || translation < 0)
        {
            Debug.LogError("Translation not normalized");
            return;
        }
        transform.position = Vector2.Lerp(railStart, railEnd, translation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = color;

        Handles.DrawLine(railStart, railEnd, 1f);
        Gizmos.DrawIcon(railStart, "Gizmo1.png");
        Gizmos.DrawIcon(railEnd, "Gizmo1.png");
    }
}
