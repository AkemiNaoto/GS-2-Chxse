using UnityEngine;

public class Raio : MonoBehaviour
{

    private Enemy Inimigo;

    void Start()
    {

        Inimigo = GetComponentInParent<Enemy>();

    }

}
