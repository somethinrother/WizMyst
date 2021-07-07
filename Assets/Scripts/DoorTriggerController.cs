using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerController : MonoBehaviour
{
    public string doorActionType;
    public DoorController door;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (doorActionType == "open" && !door.isOpen)
            {
                door.Open();
            }
            else if (doorActionType == "close" && door.isOpen)
            {
                door.Close();
            }
        }
    }
}
