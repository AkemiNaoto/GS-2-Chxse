using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class OpcoesController : MonoBehaviour
{

    private SomController Som;
    [SerializeField] private Slider MusicaSlider, SfxSlider;

    void Start()
    {

        Som = FindFirstObjectByType<SomController>();
        float Volmusica = PlayerPrefs.GetFloat("PrefMusica", 0.5f);
        float VolSfx = PlayerPrefs.GetFloat("PrefSfx", 0.5f);

        MusicaSlider.value = Volmusica;
        SfxSlider.value = VolSfx;

        AlterarVolumeMusica(Volmusica);
        AlterarVolumeSfx(VolSfx);

    }

    public void AlterarVolumeMusica(float Valor)
    {

        Som.AudioControle.SetFloat("VolumeMusga", Mathf.Log10(Valor) * 20);
        PlayerPrefs.SetFloat("PrefMusica", Valor);
        //Som.VolumeMusica = MusicaSlider.value;

    }

    public void AlterarVolumeSfx(float Valor)
    {

        Som.AudioControle.SetFloat("VolumeSFX", Mathf.Log10(Valor) * 20);
        PlayerPrefs.SetFloat("PrefSfx", Valor);
        //Som.VolumeSFX = SfxSlider.value;

    }

    public void X()
    {

        SceneManager.LoadScene("Menu Inicial");

    }

}
