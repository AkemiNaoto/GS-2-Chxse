using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] private Transform Alvo;

    void Start()
    {

        Alvo = GameObject.FindWithTag("Player").GetComponent<Transform>();

    }


    void Update()
    {

        if (Alvo != null)
        {

            transform.position = new Vector3(Alvo.position.x, Alvo.position.y - 1.0f, -10.0f);

        }


    }
}
