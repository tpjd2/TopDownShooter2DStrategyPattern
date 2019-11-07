using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    float moviment;
    Rigidbody2D rb2d;
    Vector3 mousePosition;
    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotation =
            Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        moviment = Input.GetAxis("Vertical");
        rb2d.AddForce(gameObject.transform.up * moviment * speed);
    }
}
