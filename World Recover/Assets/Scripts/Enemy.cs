using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Raio raio;

    private Vector3 Player;
    [SerializeField] Transform target;
    [SerializeField] float speed = 4f;
    [SerializeField] float stopDistance = 1f;
    [SerializeField] float axisSwitchBias = 0.2f;
    public GameObject MeuAtaque;
    public Animator Anima;
    private float Vida;
    private Player Play;
    [SerializeField] private AttackI Ataque2;
    Rigidbody2D rb;
    public bool movingOnX = true;
    public bool PodeMover = true;
    private GameController Game;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").GetComponent<Transform>();

    }

    void Start()
    {

        Anima = GetComponent<Animator>();
        Player = target.position;
        Vida = 50f;
        MeuAtaque.SetActive(false);
        Play = GameObject.FindWithTag("Player").GetComponent<Player>();
        PodeMover = true;
        Game = GameObject.Find("GameController").GetComponent<GameController>();

    }

    public void Atacar()
    {

        MeuAtaque.SetActive(true);
        // rb.linearVelocity = ;
        movingOnX = false;
        StartCoroutine("Ataque");


    }

    void FixedUpdate()
    {

        if (Player != target.position)
        {

            Anima.SetTrigger("Levantando");
            Invoke("Mover", 0.6f);

        }

    }

    public void Mover()
    {
        if (PodeMover == false)
        {

            if (movingOnX == false)
            {
                rb.linearVelocity = Vector2.zero;
                Anima.SetFloat("Andando", -1);
                return;
            }

        }

        else if (PodeMover == true)
        {

            Anima.SetFloat("Andando", 1);
            Vector2 diff = target.position - transform.position;
            float absX = Mathf.Abs(diff.x);
            float absY = Mathf.Abs(diff.y);

            if (absX < stopDistance && absY < stopDistance)
            {

                rb.linearVelocity = Vector2.zero;
                return;

            }

            if (movingOnX && absY > absX + axisSwitchBias) movingOnX = false;
            else if (!movingOnX && absX > absY + axisSwitchBias) movingOnX = true;

            if (movingOnX && absX < stopDistance) movingOnX = false;
            if (!movingOnX && absY < stopDistance) movingOnX = true;

            Vector2 dir = movingOnX
            ? new Vector2(Mathf.Sign(diff.x), 0f)
            : new Vector2(0f, Mathf.Sign(diff.y));

            rb.linearVelocity = dir * speed;

        }

        if (rb.linearVelocity.x < 0)
        {

            transform.eulerAngles = new Vector2(0f, 180f);
            Anima.SetBool("Descendo", false);
            Anima.SetBool("Subindo", false);

        }

        else if (rb.linearVelocity.x > 0)
        {

            transform.eulerAngles = new Vector2(0f, 0f);
            Anima.SetBool("Descendo", false);
            Anima.SetBool("Subindo", false);

        }

        else if (rb.linearVelocity.y < 0)
        {

            Anima.SetBool("Descendo", true);
            Anima.SetBool("Subindo", false);

        }

        else if (rb.linearVelocity.y > 0)
        {

            Anima.SetBool("Subindo", true);
            Anima.SetBool("Descendo", false);

        }

        else
        {

            Anima.SetBool("Subindo", false);
            Anima.SetBool("Descendo", false);

        }



    }

    /*void TomouDano()
    {

        if (Ataque.Acertou == true && Vida > 0f)
        {

            Vida -= Ataque.Dano;
            Ataque.Acertou = false;

        }

        else if (Ataque.Acertou == true && Vida <= 0f)
        {

            Destroy(this);
            Ataque.Acertou = false;

        }

    }*/

    public void Stun()
    {

        movingOnX = false;
        PodeMover = false;

    }

    public void StunMenor()
    {

        movingOnX = false;
        PodeMover = false;

    }

    void OnTriggerEnter2D(Collider2D Col)
    {

        if (Col.CompareTag("Ataque"))
        {

            if (Vida > 0f)
            {

                StartCoroutine("TomarDano");

            }

            else if (Vida <= 0)
            {

                Game.QntInimigos++;
                Destroy(gameObject);

            }

        }

    }

    IEnumerator Ataque()
    {

        Anima.SetBool("Atacando", true);
        yield return new WaitForSeconds(0.3f);
        Play.Vida -= 10f;
        Play.transform.position += transform.right * 1f;
        PodeMover = true;
        yield return new WaitForSeconds(0.1f);


    }

    IEnumerator TomarDano()
    {

        Vida -= 15f;
        yield return new WaitForSeconds(0.2f);
        transform.position += -transform.right * 1.5f;
        StopCoroutine("TomarDano");

    }


}


