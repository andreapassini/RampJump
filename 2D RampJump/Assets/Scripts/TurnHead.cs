using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHead : MonoBehaviour
{
    Vector2 mousePosition;

    public Camera camera;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }

	private void FixedUpdate()
	{
        Vector2 directionToLook = mousePosition - rb.position;
        float angle = Mathf.Atan2(directionToLook.y, directionToLook.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
