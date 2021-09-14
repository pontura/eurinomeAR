using UnityEngine;
using UnityEngine.UI;

public class AudioSpectrum : MonoBehaviour
{
	public AudioSource audioSource;
	float result1;
	float result2;
	float result3;
	float result4;
	float result5;

    public float multiplier = 6;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;


    void SetSize(GameObject image, float value)
    {
        image.transform.localScale = new Vector3(1, value * multiplier, 1);
    }
    public void SetOn(AudioSource audioSource)
	{
        this.audioSource = audioSource;
	}
	public void SetOff()
	{
        this.audioSource = null;    }

	void Update()
	{
		if (audioSource == null)
			return;
		
		float[] spectrum = new float[256];

		audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

		float a = 0;
		int frag = (int)(spectrum.Length / 4);
		result1 = spectrum [(frag*0)]+ spectrum [(frag*0)+1]+ spectrum [(frag*0)+2];
		result2 = -1*result1 * (Random.Range (0, 50) - 100) / 60;
		result3 = -1 * result1 * (Random.Range (0, 50) - 100) / 60;
		result4 = -1 * result1 * (Random.Range (0, 50) - 100) / 60;
		result5 = -1 * result1 * (Random.Range (0, 50) - 100) / 60;

        SetSize(image1, result1);
        SetSize(image2, result2);
        SetSize(image3, result3);
        SetSize(image4, result4);
        SetSize(image5, result5);

    }
}