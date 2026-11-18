using UnityEngine;

public class Raio : MonoBehaviour
{

    private Enemy Inimigo;

    void Start()
    {

        Inimigo = GetComponentInParent<Enemy>();

    }

    void OnTriggerEnter2D(Collider2D Col)
    {


        {

            if (Col.CompareTag("Player"))
            {
                
                Inimigo.Atacar();

            }

        }

    }

    void OnTriggerExit2D(Collider2D Col)
    {

        if (Col.CompareTag("Player"))
        {
            
            Inimigo.Mover();

        }

    }

}
