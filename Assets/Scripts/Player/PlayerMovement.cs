using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rigidBody;
    public Animator animator;
    private PlayerManager playerManager;
    public float maxXSpeed;

    public float xInput { get; private set; }
    public float yInput { get; private set; }

    private void Awake()
    {

    }

    private void Start()
    {
        playerManager = PlayerManager.instance;
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(xInput, yInput).normalized * moveSpeed;
        CheckDirection(xInput);

        rigidBody.velocity = moveDirection;
        if (playerManager.stateMachine.state != playerManager.walkState && 
            (Math.Abs(xInput) > 0 || Math.Abs(yInput) > 0))
            playerManager.SelectState(moveDirection, xInput);
        else if (playerManager.stateMachine.state != playerManager.idleState && (xInput == 0 && yInput == 0))
            playerManager.SelectState(moveDirection, xInput);


    }

    void CheckDirection(float xInput)
    {
        if (xInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (xInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}



/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 public float moveSpeed = 5f;
    
    //private Rigidbody2D _rigidBody;
    //private Animator _animator;

    public IdleState idleState;
    public WalkState walkState;
    public DeadState deadState;

    //State state;
    //StateMachine stateMachine;

    //private StateController stateController;

    public float maxXSpeed;

    public float xInput { get; private set; }
    public float yInput { get; private set; }

    private void Awake()
    {
        //_animator = GetComponent<Animator>();
        //_rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //idleState.Setup(_rigidBody, _animator, this);
        //walkState.Setup(_rigidBody, _animator, this);
        //deadState.Setup(_rigidBody, _animator, this);
        SetupInstances();
        stateMachine = new StateMachine();
        stateMachine.Set(idleState);
        //state = idleState;
        //state.Initialise();
        //state.OnEnter();

        //stateController = GetComponent<StateController>();
    }


    void Update()
    {
       // if (state == deadState && !deadState.isComplete) return;

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(xInput, yInput).normalized * moveSpeed;

        rigidBody.velocity = moveDirection;

        SelectState(moveDirection, xInput);

        //stateMachine.state.OnUpdate();

    }

    void SelectState(Vector2 moveDirection, float xInput)
    {
        //State oldState = state;
        
        if(moveDirection.magnitude > 0)
        {
            stateMachine.Set(walkState);
            //stateController.ChangeState(new WalkState());

            if (xInput < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (xInput > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        } 
        else
        {
            stateMachine.Set(idleState);

            //stateController.ChangeState(new IdleState());
        }

        //if(oldState != state || oldState.isComplete)
        //{
        //    oldState.OnExit();
        //    state.Initialise();
        //    state.OnEnter();
        //}
    }
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
void Update()
{
    if (Input.GetKey(KeyCode.W))
    {
        MoveUp();
    }
    else if (Input.GetKey(KeyCode.S))
    {
        MoveDown();
    }
    else if (Input.GetKey(KeyCode.A))
    {
        MoveLeft();
    }
    else if (Input.GetKey(KeyCode.D))
    {
        MoveRight();
    }
}

#region PlayerMovement
private void MoveUp()
{
    transform.position += force * Time.deltaTime * Vector3.up;
}

private void MoveDown()
{
    transform.position += force * Time.deltaTime * Vector3.down;
}

private void MoveLeft()
{
    transform.position += force * Time.deltaTime * Vector3.left;
    transform.rotation = Quaternion.Euler(0, 0, 0);
}

private void MoveRight()
{
    transform.position += force * Time.deltaTime * Vector3.right;
    transform.rotation = Quaternion.Euler(0, 180, 0);
}
#endregion
*/