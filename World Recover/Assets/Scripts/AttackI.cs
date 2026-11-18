using UnityEngine;

public class AttackI : MonoBehaviour
{

    private Player Play;
    private Enemy Inimigo;
    public float Dano, TempoStun, TempoStunMenor;
    public bool Stun, StunMenor;


    void Start()
    {

        Play = GameObject.FindWithTag("Player").GetComponent<Player>();
        Inimigo = GetComponentInParent<Enemy>();

    }

    void Update()
    {

        if (Stun == true)
        {

            if (TempoStun < 3f)
            {

                TempoStun += 1 * Time.deltaTime;

            }

            else if (TempoStun >= 3f)
            {

                Inimigo.movingOnX = true;
                Inimigo.PodeMover = true;
                Stun = false;

            }

        }

        else if (StunMenor == true)
        {

            if (TempoStun < 1f)
            {

                TempoStun += 1 * Time.deltaTime;

            }

            else if (TempoStun >= 1f)
            {

                Inimigo.movingOnX = true;
                Inimigo.PodeMover = true;
                Stun = false;

            }

        }

    }


}
