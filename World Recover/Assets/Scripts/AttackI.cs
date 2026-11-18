using UnityEngine;

public class AttackI : MonoBehaviour
{

    private Player Play;
    private float Dano;

    void Start()
    {

        Play = GameObject.FindWithTag("Player").GetComponent<Player>();

    }

    void OnTriggerEnter2D(Collider2D Col)
    {

        if (Col.CompareTag("Player"))
        {

            Play.Vida -= Dano;

        }

    }


}
