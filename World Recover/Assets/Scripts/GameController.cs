using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    [SerializeField] private GameObject Pause,TelaPause;

    public void BPause()
    {
        
        TelaPause.SetActive(true);
        Pause.SetActive(false);

    } 

    public void Continuar()
    {
        
        TelaPause.SetActive(false);
        Pause.SetActive(true);

    }

    public void Menu()
    {
        
        TelaPause.SetActive(true);
        Pause.SetActive(false);
        SceneManager.LoadScene("Menu Inicial");

    }

}
