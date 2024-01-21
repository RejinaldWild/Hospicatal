using UnityEngine;
using UnityEngine.Events;

public class MoveController: MonoBehaviour 
{
    const float GROUNDED_RADIUS = 0.2f;
    //const float CEILING_RADIUS = 0.2f;

    [SerializeField] public LayerMask groundLayer;

    [Range(0,1000f)][SerializeField] private float _jumpSpeed = 500f;
    [Range(0,0.5f)][SerializeField] private float _movementSmooth = 0.05f;
    [SerializeField] private bool _airControl = true;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _ceilingCheck;

    private bool _isGrounded = false;
    private Rigidbody2D _rigid;
    private bool _facingRight = true;
    private Vector3 _mVelocity = Vector3.zero;

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;


    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }

    public void Move (float move, bool jump)
    {
        Vector3 targetVelocity = new Vector3(move, _rigid.velocity.y);
        _rigid.velocity = Vector3.SmoothDamp(_rigid.velocity, targetVelocity, ref _mVelocity, _movementSmooth);
        //FindObjectOfType<AudioManager>().Play("Run");

        if (move>0 && !_facingRight)
        {
            Flip();
        }
        else if(move<0 && _facingRight)
        {
            Flip();
        }

        if(_isGrounded && jump)
        {
            FindObjectOfType<AudioManager>().Play("Jump");
            _isGrounded = false;
            _rigid.AddForce(new Vector2(0f, _jumpSpeed));
        }
    }
    void FixedUpdate()
    {
        bool wasGrounded = _isGrounded;
        _isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, GROUNDED_RADIUS, groundLayer);

        for(int i = 0;i<colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _isGrounded = true;
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
