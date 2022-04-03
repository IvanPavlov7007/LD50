using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraMovement : MonoBehaviour
{

    public float strength = 1f;
    public float snappiness = .5f;
    public float facingOffset = 3;

    public CharacterMovement characterMovement;

    public Transform cursorLight;
    public Transform player;

    public Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = (cursorLight.position - player.position) * strength;
        offset.x += facingOffset * (characterMovement.facingRight ? 1f : -1f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition + new Vector3(offset.x, offset.y, 0f), snappiness);
    }
}
