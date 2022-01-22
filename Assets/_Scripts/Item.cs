using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public float energyCost = 1;

    [SerializeField]
    bool _active = false;
    Animator _anim;

    public void Interact()
    {
        //If was active, decrement
        if (!_active)
            EnergyController.NumberOfActiveItems++;
        else
            EnergyController.NumberOfActiveItems--;

        //Flip the items active state
        _active = !_active;
        //print("Interacted with the " + this.name + " to turn it " + _active);
        _anim.SetBool("Active", _active);
    }

    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if(_active)
        {
            EnergyController.Instance.SiphonEnergy(energyCost);
        }
    }

    public bool GetActive()
    {
        return _active;
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Interact();
    }

    public string GetName()
    {
        return this.name;
    }
}
