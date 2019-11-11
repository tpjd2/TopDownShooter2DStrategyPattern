using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] string nomeArma;

    float movement;
    Rigidbody2D rb2d;
    Vector3 mousePosition;
    Quaternion rotation;
    IArma arma;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ConfigArma(nomeArma);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            arma.Atirar();
    }

    private void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotation =
            Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        movement = Input.GetAxis("Vertical");
        rb2d.AddForce(gameObject.transform.up * movement * speed);
    }

    public void ConfigArma(string tag)
    {
        switch (tag)
        {
            case "Pickup":
                RemoveArma();
                this.arma = gameObject.AddComponent<TiroSimples>();
                break;
            case "UFO":
                RemoveArma();
                this.arma = gameObject.AddComponent<TiroRaycast>();
                break;
            default:
                break;
        }
    }

    void RemoveArma()
    {
        // PARA EVITAR A CRIACAO DE MULTIPLOS COMPONENTES DO MESMO TIPO NO GAMEOBJECT 
        Component c = gameObject.GetComponent<IArma>() as Component;
        if (c != null) Destroy(c);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ConfigArma(collision.tag);
    }
}
