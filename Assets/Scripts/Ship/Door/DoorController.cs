using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Transform body;
    // Start is called before the first frame update
    void Start()
    {
        body = transform.Find("Body");
    }

    public void Open()
    {
        body.gameObject.SetActive(false);
    }

    public void Close()
    {
        body.gameObject.SetActive(true);
    }


}
