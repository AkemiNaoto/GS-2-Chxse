using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SomController : MonoBehaviour
{

    public AudioMixer AudioControle;
    public AudioSource ControleSom;
    private AudioMixerGroup Grupo;
    public bool Tocando = false;
    [SerializeField] private AudioClip SomMenu;
    [SerializeField] private AudioClip SomGameplay;
    [SerializeField] private AudioClip SomCutscene;
    private string CenaAtual;
    //public float VolumeMusica, VolumeSFX;
    private static SomController istancia;
    void Awake()
    {

        if (istancia != null && istancia != this)
        {

            Destroy(gameObject);
            return;

        }

        istancia = this;
        DontDestroyOnLoad(this);



    }
    void Start()
    {

        ControleSom = GetComponent<AudioSource>();

    }


    void Update()
    {

        CenaAtual = SceneManager.GetActiveScene().name;
        Tocando = ControleSom.isPlaying;

        if (CenaAtual == "Menu Inicial" || CenaAtual == "Configuracoes" || CenaAtual == "Creditos")
        {

            TrocarMusica(SomMenu);

        }

        else if (CenaAtual == "Gameplay")
        {

            TrocarMusica(SomGameplay);

        }

        else if (CenaAtual == "Cutscene")
        {

            if (ControleSom.clip == SomCutscene && ControleSom.isPlaying)
            {

                return;

            }
            ControleSom.Stop();
            ControleSom.clip = SomCutscene;
            Invoke("Tocar", 0.5f);

        }

    }


    public void TrocarMusica(AudioClip novaMusica)
    {

        if (novaMusica == null)

            return;

        if (ControleSom.clip == novaMusica && ControleSom.isPlaying)
        {

            return;

        }

        ControleSom.Stop();
        ControleSom.clip = novaMusica;
        ControleSom.loop = true;
        Tocar();

    }

    public void Tocar()
    {

        ControleSom.Play();

    }

}



