using System;
using System.Xml;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer Sr;
    [SerializeField] private float ProxAtaque;
    private float Velocidade = 5.0f;
    private float ParryCooldown = 5.0f;
    [SerializeField] private float TempoAtual = 0.0f;
    [SerializeField] private bool ParryActive = true;
    [SerializeField] private GameObject Ataque;
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
        Attack();

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

    public void Attack()
    {

        int AtaqueSeguido = 0;

        if (Input.GetKey(KeyCode.J))
        {

            Anima.ResetTrigger("Ataque");
            Anima.SetTrigger("Ataque");
            Ataque.SetActive(true);
            Invoke("OffAttack", 0.42f);


            /*if (AtaqueSeguido == 0 && ProxAtaque == 0.0f)
            {

                Anima.ResetTrigger("Ataque");
                Anima.SetTrigger("Ataque");
                ProxAtaque += 1 * Time.deltaTime;
                AtaqueSeguido++;
                Ataque.SetActive(true);
                Invoke("OffAttack", 0.42f);

            }

            else if (AtaqueSeguido == 1 && ProxAtaque == 0.25f)
            {

                Anima.ResetTrigger("Ataque2");
                Anima.SetTrigger("Ataque2");
                ProxAtaque += 1 * Time.deltaTime;
                AtaqueSeguido++;

            }

            else if (AtaqueSeguido == 2 && ProxAtaque == 0.50f)
            {

                Anima.ResetTrigger("Ataque3");
                Anima.SetTrigger("Ataque3");
                ProxAtaque += 1 * Time.deltaTime;
                AtaqueSeguido++;

            }

            else if (AtaqueSeguido == 3 && ProxAtaque == 0.75f)
            {

                Anima.ResetTrigger("Ataque4");
                Anima.SetTrigger("Ataque4");
                ProxAtaque += 1 * Time.deltaTime;
                AtaqueSeguido++;

            }*/

        }

    }

    public void OffAttack()
    {

        Ataque.SetActive(false);

    }

}
