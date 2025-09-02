using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody))]
    public class ThirdPersonCharacter : MonoBehaviour
    {
        private Animator animator;
        private Rigidbody rb;
        private bool isGrounded = true;

        [Header("Movement Settings")]
        public float moveSpeed = 5f;
        public float turnSpeed = 10f;

        private void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();

            if (rb != null)
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        // Called by AICharacterControl or Player script
        public void Move(Vector3 move, bool crouch, bool jump)
        {
            if (move.magnitude > 1f)
                move.Normalize();

            // Apply movement
            Vector3 desiredMove = move * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + desiredMove);

            // Rotate towards movement direction
            if (move != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            }

            // Animator (optional)
            if (animator != null)
            {
                float forwardAmount = move.magnitude;
                animator.SetFloat("Forward", forwardAmount);
            }
        }
    }
}
