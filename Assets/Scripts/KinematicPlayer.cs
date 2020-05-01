using UnityEngine;

[RequireComponent(typeof(KinematicBody))]
public class KinematicPlayer : MonoBehaviour
{
	public float speed = 12.0f;
	public float jumpSpeed = 15.0f;
	public float gravity = 35.0f;
    public float snapForce = 10.0f;

    private KinematicBody kinematicBody;

    private void Start()
    {
        kinematicBody = GetComponent<KinematicBody>();
    }

    private void FixedUpdate()
    {
        //  Always deriv your motion from the kinematic body velocity
        //  otherwise your movement will be incorrect, like when you
        //  jump against a ceiling and don't fall since your motion 
        //  still being applied against its direction.
        Vector3 moveDirection = kinematicBody.velocity;

        if (kinematicBody.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = moveDirection.normalized;
            moveDirection *= speed;

            //  If te kinematic body is grounded you should always apply velocity downward
            //  to keep the isGrounded status as true and avoid the "bunny hop" effect when
            //  walking down steep ground surfaces.
            moveDirection.y = -snapForce;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        // Call the Move method from Kinematic Body with the desired motion.
        kinematicBody.Move(moveDirection);
    }
}
