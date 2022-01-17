using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    public static EnergyController Instance;

    float _energyLevel;

    [SerializeField]
    Text _energyText;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _energyLevel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        _energyText.text = "Energy: " + ((int)_energyLevel).ToString();
    }

    public void SiphonEnergy(float reduction)
    {
        _energyLevel -= reduction * Time.deltaTime;
    }
}
