using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    public static EnergyController Instance;
    public static int NumberOfActiveItems;

    float _energyLevel;

    [SerializeField]
    Text _energyText;

    [SerializeField]
    SpriteRenderer _boltSpriteRenderer;

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
        NumberOfActiveItems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _energyText.text = "Energy: " + ((int)_energyLevel).ToString();
        _boltSpriteRenderer.color = Color.Lerp(Color.green, Color.red, NumberOfActiveItems * 0.25f);
    }

    public void SiphonEnergy(float reduction)
    {
        _energyLevel -= reduction * Time.deltaTime;
    }
}
