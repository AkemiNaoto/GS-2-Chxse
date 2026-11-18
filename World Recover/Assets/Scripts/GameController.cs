using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject Pause, TelaPause, Win, GameOver;
    [SerializeField] private Slider Vida, Estamina;
    [SerializeField] private Player P;
    public int QntInimigos;
    private SomController Som;
    private bool jogoFinalizado = false;

    void Start()
    {
        // 1. Garante que o tempo volte ao normal logo no primeiro milissegundo
        Time.timeScale = 1.0f;
        jogoFinalizado = false;
        QntInimigos = 0;

        // 2. Busca os objetos primeiro, antes de mexer nas variáveis deles
        GameObject objPlayer = GameObject.FindWithTag("Player");
        if (objPlayer != null)
        {
            P = objPlayer.GetComponent<Player>();
            P.TempoAtual = 3f;
        }

        GameObject objAudio = GameObject.FindWithTag("Audio");
        if (objAudio != null)
        {
            Som = objAudio.GetComponent<SomController>();
        }
    }

    void Update()
    {
        if (P != null)
        {
            Vida.value = P.Vida;
            Estamina.value = P.TempoAtual;

            // Só executa uma única vez quando o jogo acaba
            if (!jogoFinalizado && P.Vida <= 0f)
            {
                jogoFinalizado = true;
                Time.timeScale = 0.0f;
                GameOver.SetActive(true);
            }
        }

        if (!jogoFinalizado && QntInimigos >= 7)
        {
            jogoFinalizado = true;
            Time.timeScale = 0.0f;
            Win.SetActive(true);
        }
    }

    public void BPause()
    {
        Time.timeScale = 0.0f;
        TelaPause.SetActive(true);
        Pause.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Gameplay");
    }

    public void Continuar()
    {
        Time.timeScale = 1.0f;
        TelaPause.SetActive(false);
        Pause.SetActive(true);
    }

    public void Menu()
    {
        // Adicionado o reset do tempo antes de ir para o Menu
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu Inicial");
    }

    public void VidaSlide()
    {
        Vida.value = P.Vida;
    }

    public void EstaminaSlide()
    {
        Estamina.value = P.TempoAtual;
    }
}