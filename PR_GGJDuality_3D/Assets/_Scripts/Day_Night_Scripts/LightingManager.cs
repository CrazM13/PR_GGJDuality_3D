using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{

    [SerializeField]private Light DirectionalLight;
    [SerializeField]private LightingPreset Preset;
    [SerializeField] private GameObject switchPlatforms;

    [SerializeField, Range(0, 1)] private float timeOfDay;

    private void OnValidate()
    {
        if(DirectionalLight != null)
        {
            return;
        }

        if(RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        switchPlatforms = GameObject.FindGameObjectWithTag("time");
        timeOfDay = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Preset == null)
        {
            return;
        }

        if(switchPlatforms.GetComponent<SwitchPlatforms>().getDay() == true)
        {
            if(timeOfDay < 0.7f)
            {
                timeOfDay += Time.deltaTime;
            }
            updateLighting(timeOfDay);
        }

        if(switchPlatforms.GetComponent<SwitchPlatforms>().getDay() == false)
        {
            if(timeOfDay > 0f)
            {
                timeOfDay -= Time.deltaTime;
            }
            updateLighting(timeOfDay);
        }
    }

    private void updateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.ambientColor.Evaluate(timeOfDay);
        RenderSettings.fogColor = Preset.fogColor.Evaluate(timeOfDay);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.directionalColor.Evaluate(timeOfDay);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 90f, 170f, 0));
        }
    }
}
