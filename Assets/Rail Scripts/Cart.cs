using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cart : MonoBehaviour
{
    RailMovement rail;

    [SerializeField] Text railtext;
    [SerializeField] Text destinationText;

    // Start is called before the first frame update
    void Start()
    {
        rail = GetComponent<RailMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 destination, Vector3 startPos)
    {

        destination.z = 0;

        destinationText.text = destination.ToString();
        var railDifference =  rail.railEnd - rail.railStart;

        railtext.text = (railDifference).ToString();

        var newPos = Vector3.Project(destination, railDifference);
        //newPos.x = newPos.x + railDifference.x;
        //newPos.y = newPos.y - railDifference.y;
        newPos = newPos - (Vector3) rail.railStart;
        newPos.x += rail.railEnd.x + rail.railStart.x;
        transform.position = newPos;

    }
}
