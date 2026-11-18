using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private SomController Som;
    [SerializeField] private GameObject Confirmacao;

    void Start()
    {

        Som = GameObject.FindWithTag("Audio").GetComponent<SomController>();
        Confirmacao.SetActive(false);

    }
    public void Jogar()
    {

        Confirmacao.SetActive(true);

    }

    public void Sim()
    {

        SceneManager.LoadScene("Cutscene");

    }

    public void Nao()
    {

        SceneManager.LoadScene("Gameplay");

    }

    public void Opcoes()
    {

        SceneManager.LoadScene("Configuracoes");

    }

    public void Creditos()
    {

        SceneManager.LoadScene("Creditos");

    }
    public void Sair()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

    }

}
