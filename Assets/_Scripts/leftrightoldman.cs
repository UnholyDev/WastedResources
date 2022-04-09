using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class leftrightoldman : MonoBehaviour
{

    public static leftrightoldman OldMan;

    public float moveSpeed;
    public Animator animator;
    public AudioSource oldmanwalking;
    // bool isMoving = false;

    public List<IInteractable> _interactionList;

    public bool _goThroughDoor = false;
    public Transform _currentDoor = null;

    private void Awake()
    {
        if (OldMan != null)
            Destroy(this.gameObject);
        else
            OldMan = this;
    }

    //bool facingRight=0;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.5f;

        oldmanwalking = GetComponent<AudioSource>();

        _interactionList = new List<IInteractable>();
    }// Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);

        Vector3 characterScale = transform.localScale;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(IInteractable i in _interactionList)
            {
                i.Interact();
            }
            
            if(_currentDoor != null && _goThroughDoor == true)
            {
                transform.position = _currentDoor.position;
            }
        }


        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
            animator.SetFloat("Horizontal", 1);
            if (!oldmanwalking.isPlaying)
            {
                oldmanwalking.Play();
            }

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
            animator.SetFloat("Horizontal", 1);
            if (!oldmanwalking.isPlaying)
            {
                oldmanwalking.Play();
            }

        }
        else
        {
            animator.SetFloat("Horizontal", 0);
            if (oldmanwalking.isPlaying)
            {
                oldmanwalking.Pause();
            }

        }
        transform.localScale = characterScale;

    }

    public void ChangePosition(Vector2 pos, RoomManager rm)
    {
            transform.position  = pos;
            //_roomManager = rm;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteractable>() != null)
            _interactionList.Add(collision.GetComponent<IInteractable>());

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteractable>() != null)
            _interactionList.Remove(collision.GetComponent<IInteractable>());
    }
}
