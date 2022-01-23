using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string roomName;

    public Transform _leftBoundary, _rightBoundary;

    [SerializeField]
    private bool _hasActive = false;

    [SerializeField]
    Item[] _roomItemsList;

    void Start()
    {
        _roomItemsList = GetComponentsInChildren<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        _hasActive = CheckHasActive();
    }

    bool CheckHasActive()
    {
        for(int i = 0; i < _roomItemsList.Length; i++)
        {
            if(_roomItemsList[i].GetActive())
                return true;
        }
        return false;
    }

    public bool GetHasActive()
    {
        return _hasActive;
    }
}
