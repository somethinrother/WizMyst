using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen;
    public int openAngle;
    public int closedAngle;
    private Vector3 rotationVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isOpen)
        {
            setAngle(openAngle);
        }
        else if (!isOpen)
        {
            setAngle(closedAngle);
        }
    }

    public void Open()
    {
        isOpen = true;
    }

    public void Close()
    {
        
        isOpen = false;
    }

    private void setAngle(int newZValue)
    {
        rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = newZValue;
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
