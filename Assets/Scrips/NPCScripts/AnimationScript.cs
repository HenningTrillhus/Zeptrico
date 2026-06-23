using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Pathfinding pathfinding;
    private NPCStats npcStats;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorForLegs;

    private int colorOfClothes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        npcStats = GetComponent<NPCStats>();
        colorOfClothes = npcStats.colorOfClothes;
        Debug.Log( colorOfClothes);
        if (colorOfClothes == 0)
        {
            animator.SetInteger("Color", 0);
        }
        if (colorOfClothes == 1)
        {
            animator.SetInteger("Color", 1);
        }
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
