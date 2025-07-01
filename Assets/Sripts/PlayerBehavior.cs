using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _vInput;
    private float _hInput;

    public float JumpVelocity = 5f;
    private bool _isJumping;
    private Rigidbody _rb;

    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _col =GetComponent<CapsuleCollider>();
    }
    private void Update()
    {
        _isShooting |= Input.GetKeyDown(KeyCode.Mouse0);
        _isJumping |= Input.GetKeyDown(KeyCode.J);
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        /*
        this.transform.Translate(Vector3.forward * _vInput *Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
    */
        }

    private void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);

        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);

        }
        _isJumping = false;

        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(0, 0, 1), this.transform.rotation);

        Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();

            BulletRB.linearVelocity = this.transform.forward * BulletSpeed;
        }
        _isShooting = false;
    }

    private bool IsGrounded()
    {
        // 7
        Vector3 capsuleBottom = new
       Vector3(_col.bounds.center.x,
        _col.bounds.min.y, _col.bounds.center.z);

        // 8
        bool grounded =
       Physics.CheckCapsule(_col.bounds.center,
        capsuleBottom, DistanceToGround,
       GroundLayer, QueryTriggerInteraction.Ignore);

        // 9
        return grounded;
    }
}
