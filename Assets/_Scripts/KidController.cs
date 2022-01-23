using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidController : MonoBehaviour
{

    public Transform _leftBound;
    public Transform _rightBound;

    public float _speed = 5;

    //public RoomManager _roomManager;

    private bool _movingLeft = false;

    private Vector2 _currentPosition;
    private Animator anim;

    private bool _canGoThroughDoor = true;

    [SerializeField]
    public RoomManager _roomManager;

    // Start is called before the first frame update
    void Awake()
    {
        _currentPosition = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentPosition.x > _roomManager._rightBoundary.position.x)
        {
            _movingLeft = true;
        }

        if (_currentPosition.x < _roomManager._leftBoundary.position.x)
        {
            _movingLeft = false;
        }

        if (_movingLeft)
        {
            _currentPosition -= new Vector2(_speed * Time.deltaTime, 0f);
            transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else
        {
            _currentPosition += new Vector2(_speed * Time.deltaTime, 0f);
            transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
        }

        transform.position = _currentPosition;

        anim.SetBool("Walking", true);
    }

    public void ChangePosition(Vector2 pos, RoomManager rm)
    {
        if(_canGoThroughDoor)
        {
            _currentPosition = pos;
            _roomManager = rm;
            StartCoroutine(DoorDelayTimer());
        }
    }
    IEnumerator DoorDelayTimer()
    {
        _canGoThroughDoor = false;
        _movingLeft = false;
        yield return new WaitForSeconds(0.5f);
        _canGoThroughDoor = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("hit");
        IInteractable inter = collision.GetComponent<IInteractable>();

        if (inter != null && !inter.GetActive())
        {
            //print("interacting with " + inter.GetName());
            inter.Interact();
        }
    }

    
}
