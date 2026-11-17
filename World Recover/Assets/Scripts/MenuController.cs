using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private SomController Som;

    void Start()
    {

        Som = GameObject.FindWithTag("Audio").GetComponent<SomController>();

    }
    public void Jogar()
    {

        SceneManager.LoadScene("Cutscene");

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
