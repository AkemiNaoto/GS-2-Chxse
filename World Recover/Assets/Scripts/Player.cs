using System;
using System.Xml;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer Sr;
    private float Velocidade = 5.0f;
    private float ParryCooldown = 5.0f;
    [SerializeField] private float TempoAtual = 0.0f;
    [SerializeField] private bool ParryActive = true;
    private Animator Anima;

    void Start()
    {

        Sr = GetComponent<SpriteRenderer>();
        Anima = GetComponent<Animator>();
        ParryActive = true;

    }


    void Update()
    {

        Mover();
        Parry();

    }

    public void Mover()
    {

        float Horizontal = Input.GetAxisRaw("Horizontal") * Velocidade * Time.deltaTime;
        float Vertical = Input.GetAxisRaw("Vertical") * Velocidade * Time.deltaTime;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {

            transform.eulerAngles = new Vector2(0, 180);
            transform.Translate(Horizontal * -1.0f, Vertical, 0.0f);

        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {

            transform.eulerAngles = new Vector2(0, 0);
            transform.Translate(Horizontal, Vertical, 0.0f);


        }

        else if (Input.GetAxisRaw("Vertical") < 0)
        {

            Anima.SetBool("Subir", true);
            Anima.SetBool("Descer", false);
            transform.Translate(Horizontal, Vertical, 0.0f);


        }

        else if (Input.GetAxisRaw("Vertical") > 0)
        {

            Anima.SetBool("Descer", true);
            Anima.SetBool("Subir", false);
            transform.Translate(Horizontal, Vertical, 0.0f);


        }

        else if (Input.GetKey(KeyCode.J))
        {

            Anima.ResetTrigger("Ataque");
            Anima.SetTrigger("Ataque");

        }

        else
        {

            Anima.SetBool("Subir", false);
            Anima.SetBool("Descer", false);

        }

        Anima.SetFloat("Andando", Math.Abs(Input.GetAxisRaw("Horizontal")));


    }

    public void Parry()
    {

        if (ParryActive == false && TempoAtual < ParryCooldown)
        {

            Anima.SetBool("Parry", false);
            TempoAtual += 1 * Time.deltaTime;

        }

        else if (ParryActive == false && TempoAtual >= ParryCooldown)
        {

            TempoAtual = 0;
            ParryActive = true;

        }

        else if (ParryActive == true)
        {

            if (Input.GetKey(KeyCode.K))
            {

                Anima.SetBool("Parry", true);
                ParryActive = false;

            }

        }

    }
}
