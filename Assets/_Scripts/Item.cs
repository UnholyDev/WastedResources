using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public float energyCost = 1;

    bool _active = false;
    Animator _anim;
    public AudioSource sound;
  
    public void Interact()
    {
        //Flip the items active state
        _active = !_active;
        print("Interacted with the " + this.name + " to turn it " + _active);
        _anim.SetBool("Active", _active);
            
        
        if(!sound.isPlaying)
        {
            sound.Play();
        }
        else
        {
            sound.Pause();
        }
              
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        sound = GetComponent<AudioSource>();
        
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
}
