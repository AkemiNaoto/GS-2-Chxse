using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void Jogar()
    {

        SceneManager.LoadScene("");

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
