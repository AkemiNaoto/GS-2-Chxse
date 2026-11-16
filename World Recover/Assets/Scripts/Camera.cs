using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] private Transform Alvo, Cam;
    [SerializeField] private Transform[] Limites;

    void Start()
    {

        Alvo = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Cam = GetComponent<Transform>();

    }


    void Update()
    {

        transform.position = new Vector3(Alvo.position.x, Alvo.position.y, -10.0f);

    }

}



