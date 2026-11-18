using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject Pause, TelaPause;
    [SerializeField] private Slider Vida, Estamina;
    [SerializeField] private Player P;
    private SomController Som;

    void Start()
    {

        P.TempoAtual = 3f;
        Som = GameObject.FindWithTag("Audio").GetComponent<SomController>();
        P = GameObject.FindWithTag("Player").GetComponent<Player>();

    }

    void Update()
    {

        Vida.value = P.Vida;
        Estamina.value = P.TempoAtual;

    }

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
