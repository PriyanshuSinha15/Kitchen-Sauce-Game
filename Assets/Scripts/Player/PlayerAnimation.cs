using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Player player;
    private Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool(IS_WALKING, player.IsWalking());
    }
}
