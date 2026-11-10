using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform Player, Inimigo;
    private float DistanciaFinal;

    void Start()
    {

        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Inimigo = GetComponent<Transform>();

    }


    void Update()
    {

    }

    void Seguir() { }

    void MaisProximo()
    {

        float DistanciaX, DistanciaY;

        if (Inimigo.transform.position.x < 0)
        {

            if (Player.transform.position.x >= 0)
            {

                DistanciaX = (Inimigo.transform.position.x * -1) + Player.transform.position.x;

            }

            else if (Player.transform.position.x < 0)
            {

                DistanciaX = (Inimigo.transform.position.x - Player.transform.position.x) * -1;

            }

        }

        else if (Inimigo.transform.position.x >= 0)
        {

            if (Player.transform.position.x >= 0)
            {

                DistanciaX = Inimigo.transform.position.x + Player.transform.position.x;

            }

            else if (Player.transform.position.x < 0)
            {

                DistanciaX = Inimigo.transform.position.x + (Player.transform.position.x * -1);

            }

        }

        if (Inimigo.transform.position.y < 0)
        {

            if (Player.transform.position.y >= 0)
            {

                DistanciaY = (Inimigo.transform.position.y * -1) + Player.transform.position.y;

            }

            else if (Player.transform.position.x < 0)
            {

                DistanciaY = (Inimigo.transform.position.y - Player.transform.position.y) * -1;

            }

        }

        else if (Inimigo.transform.position.y >= 0)
        {

            if (Player.transform.position.y >= 0)
            {

                DistanciaY = Inimigo.transform.position.y + Player.transform.position.y;

            }

            else if (Player.transform.position.y < 0)
            {

                DistanciaY = Inimigo.transform.position.y + (Player.transform.position.y * -1);

            }

        }

    }

}


