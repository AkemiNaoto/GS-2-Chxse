using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer Sr;
    [SerializeField] private float ProxAtaque;
    private float Velocidade = 5.0f;
    private float Estamina = 3.0f;
    public float TempoAtual = 0.0f;
    [SerializeField] private bool ParryActive = true;
    [SerializeField] private GameObject Ataque;
    private Animator Anima;
    public float Vida = 100f;
    public bool UsouParry = false;

    void Start()
    {

        Sr = GetComponent<SpriteRenderer>();
        Anima = GetComponent<Animator>();
        ParryActive = true;
        UsouParry = false;

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

        if (ParryActive == false && TempoAtual < Estamina)
        {

            Anima.SetBool("Parry", false);
            TempoAtual += 1 * Time.deltaTime;
            UsouParry = false;

        }

        else if (ParryActive == false && TempoAtual >= Estamina)
        {

            TempoAtual = 3;
            ParryActive = true;

        }

        else if (ParryActive == true)
        {

            if (Input.GetKey(KeyCode.K))
            {

                Anima.SetBool("Parry", true);
                UsouParry = true;
                ParryActive = false;
                TempoAtual = 0;

            }

        }

    }

    public void Attack()
    {

        //int AtaqueSeguido = 0;

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

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "Visao")
        {
            if (UsouParry == true)
            {

                Col.GetComponentInParent<Enemy>().Stun();
                Col.GetComponentInParent<Enemy>().transform.position += transform.right * 1f;
                Col.GetComponent<AttackI>().Stun = true;
                Col.GetComponent<AttackI>().TempoStun = 0f;

            }

            else if (UsouParry == false)
            {

                Col.GetComponentInParent<Enemy>().Invoke("Atacar", 0.5f);
                Col.GetComponentInParent<Enemy>().PodeMover = false;

            }

        }

        if (Col.tag == "AtaqueInimigo")
        {

            if (UsouParry == true)
            {

                Col.GetComponentInParent<Enemy>().Stun();
                Col.GetComponent<AttackI>().Stun = true;
                Col.GetComponent<AttackI>().TempoStun = 0f;

            }

            else if (UsouParry == false)
            {

                Vida -= 10f;

            }

        }

    }

    void OnTriggerExit2D(Collider2D Col)
    {

        if (Col.tag == "Visao")
        {

            Col.GetComponentInParent<Enemy>().StopCoroutine("Ataque");
            Col.GetComponentInParent<Enemy>().movingOnX = true;
            Col.GetComponentInParent<Enemy>().MeuAtaque.SetActive(false);
            Col.GetComponentInParent<Enemy>().PodeMover = true;

        }

    }

}
