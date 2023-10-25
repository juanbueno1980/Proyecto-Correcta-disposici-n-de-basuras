using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float movr=200.0f;
    public float movementSpeed=5.0f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        transform.Rotate(0, hor * Time.deltaTime * movr, 0);
        transform.Translate(0, 0, ver * Time.deltaTime * movementSpeed);
        anim.SetFloat("hor", hor);
        anim.SetFloat("ver", ver);
    }
}
