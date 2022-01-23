using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Transform _pairedDoor;
    public RoomManager _roomManager;

    [SerializeField]
    bool _active = false;

    Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _pairedDoor.GetComponent<Door>().ActivatePairedDoor(_roomManager.GetHasActive());
    }

    public void Interact()
    {
        //Debug.Log("Interacted with door");
        _active = !_active;
        _anim.SetBool("Active", _active);
    }
    public bool GetActive()
    {
        return _active;
    }
    public string GetName()
    {
        return this.name;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //When something interacts with the door, move it.
        //For now just deletes the child
        if(other.GetComponent<KidController>() != null)
        {
            other.GetComponent<KidController>().ChangePosition(_pairedDoor.position);
        }

        if (other.GetComponent<leftrightoldman>() != null)
        {
            //other.GetComponent<leftrightoldman>().ChangePosition(_pairedDoor.position);
        }
    }

    public void ActivatePairedDoor(bool activate)
    {
        _anim.SetBool("Active", activate);
    }
}
