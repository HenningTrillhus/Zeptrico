using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Pathfinding pathfinding;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorForLegs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pathfinding.isMoving)
        {
            // Play walking animation
            animator.SetBool("Walking", true);
            animatorForLegs.SetBool("IsWalking", true);
        }
        else
        {
            // Play idle animation
            animator.SetBool("Walking", false);
            animatorForLegs.SetBool("IsWalking", false);
        }
    }
}
