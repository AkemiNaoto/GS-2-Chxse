using System;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer Sr;
    private float Velocidade = 5.0f;
    private Animator Anima;

    void Start()
    {

        Sr = GetComponent<SpriteRenderer>();
        Anima = GetComponent<Animator>();

    }


    void Update()
    {

        Mover();

    }

    public void Mover()
    {

        transform.Translate(Input.GetAxisRaw("Horizontal") * Velocidade * Time.deltaTime, Input.GetAxisRaw("Vertical") * Velocidade * Time.deltaTime, 0.0f);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {

            Sr.flipX = true;


        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {

            Sr.flipX = false;

        }

        else if (Input.GetKey(KeyCode.J))
        {

            Anima.ResetTrigger("Ataque");
            Anima.SetTrigger("Ataque");

        }

        Anima.SetFloat("Andando", Math.Abs(Input.GetAxisRaw("Horizontal")));


    }
}
