using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private transform Player;

    void Start()
    {
        
        Player = Gameobject.FindWithTag("Player").GetComponent<transform>();

    }

    
    void Update()
    {
        
    }



}
