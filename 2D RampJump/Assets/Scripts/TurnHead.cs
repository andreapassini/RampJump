using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHead : MonoBehaviour
{
    Vector2 mousePosition;

    public Camera camera;

    Rigidbody2D rb;

    [SerializeField] GameObject player;
    [SerializeField] Transform gunPos;

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
        //transform.position = gunPos.transform.position;

        Vector2 directionToLook = mousePosition - (Vector2)gunPos.position;
        float angle = Mathf.Atan2(directionToLook.y, directionToLook.x) * Mathf.Rad2Deg - 90f;
        Quaternion angleQ = Quaternion.Euler(0f, 0f, angle);
        gunPos.rotation = angleQ;
    }
}
