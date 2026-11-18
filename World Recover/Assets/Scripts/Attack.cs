using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int QntFrames = 15;
    [SerializeField] private int FramesAmais = 6;
    private int frameCounter = 0;
    private bool parryRequested;
    public bool IsParrying => frameCounter > 0;
    public float Dano = 15f;
    public bool Acertou = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))

            parryRequested = true;

    }

    void FixedUpdate()
    {

        if (parryRequested)
        {
            frameCounter = QntFrames + FramesAmais;
            parryRequested = false;

        }

        if (frameCounter > 0)
            frameCounter--;

    }

    void OnTriggerEnter2D(Collider2D Col)
    {

        if(Col.CompareTag("Enemy"))
        {
            
           Acertou = true; 

        }
        
    }
}