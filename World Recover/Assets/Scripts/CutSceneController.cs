using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour
{

    private SpriteRenderer ImagemCut;
    [SerializeField] private Sprite[] Imagens;

    void Start()
    {

        ImagemCut = GameObject.FindWithTag("Cutscene").GetComponent<SpriteRenderer>();
        StartCoroutine(Animacao());


    }


    void Update()
    {



    }

    IEnumerator Animacao()
    {

        ImagemCut.color = new Color(0f, 0f, 0f, 1f);
        ImagemCut.sprite = Imagens[0];

        yield return new WaitForSeconds(2f);

        ImagemCut.color = new Color(1f, 1f, 1f, 1f);

        yield return new WaitForSeconds(14f);

        ImagemCut.sprite = Imagens[1]; //Olhos abertos

        yield return new WaitForSeconds(14f);

        ImagemCut.sprite = Imagens[2]; //Robô sugando água

        yield return new WaitForSeconds(12f);

        ImagemCut.sprite = Imagens[3]; //Máquina do tempo

        yield return new WaitForSeconds(13f);

        ImagemCut.sprite = Imagens[4]; //Prédio

        yield return new WaitForSeconds(5f);

        ImagemCut.sprite = Imagens[5]; //Hospedeira

        yield return new WaitForSeconds(10f);

        ImagemCut.color = new Color(0f, 0f, 0f, 255f);
        SceneManager.LoadScene("Gameplay");

    }


}
