using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class DoorController : MonoBehaviour
{

    public Transform doorBlock;
    public float distance;
    public float time;

    public bool open = false;
     
    public AudioSource openSource;  // ;P hehehe
    public AudioSource closedSource; 

    private Vector3 closedPosition;
    // Start is called before the first frame update
    void Start()
    {
        closedPosition = doorBlock.position;
    }

    public void Open()
    {
        if(!open)
        {
            openSource.Play();
            Tween.Position(doorBlock, closedPosition, closedPosition - new Vector3(0, distance, 0), time, 0);
            open = true;
        }
    }
    
    public void Close()
    {
        if(open) { 
            closedSource.Play();
            Tween.Position(doorBlock, closedPosition - new Vector3(0, distance, 0), closedPosition, time, 0);
            open = false;
        }
    }
}
