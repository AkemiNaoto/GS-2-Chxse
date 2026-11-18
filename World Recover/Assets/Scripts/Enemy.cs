using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Vector3 Player;
    [SerializeField] Transform target;
    [SerializeField] float speed = 4f;
    [SerializeField] float stopDistance = 1f;
    [SerializeField] float axisSwitchBias = 0.2f;
    private Attack Ataque;
    private Animator Anima;
    private float Vida;

    Rigidbody2D rb;
    bool movingOnX = true;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Start()
    {

        Anima = GetComponent<Animator>();
        Player = target.position;
        Vida = 50f;
        Ataque = GameObject.FindWithTag("Ataque").GetComponent<Attack>();

    }

    public void Atacar()
    {
        
        rb.linearVelocity = Vector2.zero;
        Anima.SetTrigger("Atacando");

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

        Anima.SetFloat("Andando", Math.Abs(rb.linearVelocity.x));

    }

    void TomouDano()
    {
        
        if(Ataque.Acertou == true && Vida > 0f)
        {
            
            Vida -= Ataque.Dano;
            Ataque.Acertou = false;

        }

        else if(Ataque.Acertou == true && Vida <= 0f)
        {
            
            Destroy(this);
            Ataque.Acertou = false;

        }

    }
}


