using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float wavelength = 10f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float offset = 0f;

    public static WaveManager Instance = null;
    
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;

            GameObject Waves = GameObject.Find("Waves");
            Material WaveMaterial = Waves.GetComponent<MeshRenderer>().material;
            WaveMaterial.SetFloat("_Amplitude", amplitude);
            WaveMaterial.SetFloat("_Wavelength", wavelength);
            WaveMaterial.SetFloat("_Speed", speed);

            Debug.Log("New WaveManager Instance Created."); 
        } else
        {
            Destroy(this);
        }
    }

    public float GetWaveHeight(float x, float z)
    {
        float k = 2 * Mathf.PI / wavelength;
        return amplitude * Mathf.Sin(k * (x - Time.timeSinceLevelLoad * speed));
    }
 
}
