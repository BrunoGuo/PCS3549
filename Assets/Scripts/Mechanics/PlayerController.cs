using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;
        private bool canCarry = false;

        bool jump;
        Vector2 move;
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        private bool isPressed = false;

        public List<ItemController> items = new List<ItemController>();

        public Timer timer;

        Vector2 upForce;

        private Rigidbody2D m_rigidbody;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            timer = GetComponent<Timer>();
            getActiveComponents();
            Debug.Log("AWAKE " + animator.name);
        }

        void getActiveComponents()
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeInHierarchy)
                {
                    Debug.Log(child.gameObject.name + " is active? " + child.gameObject.activeInHierarchy.ToString());
                    collider2d = child.gameObject.GetComponent<Collider2D>();
                    spriteRenderer = child.gameObject.GetComponent<SpriteRenderer>();
                    animator = child.gameObject.GetComponent<Animator>();
                    if (child.gameObject.name != "pink") 
                    {
                        animator.SetBool("infecting", true);
                    }
                    else
                    {
                        animator.SetBool("infecting", false);
                    }
                }
            }
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                if (isPressed)
                {
                    Debug.Log("PRESSED");
                }
                else if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (canFly && Input.GetKey(KeyCode.W))
            {
                velocity.y = jumpTakeOffSpeed;
            }
            else if (canFly && Input.GetKey(KeyCode.S))
            {
                velocity.y = -jumpTakeOffSpeed / 2;
            }
            else if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        void OnMouseDown()
        {
            isPressed = true;
        }

        void OnMouseUp()
        {
            isPressed = false;
        }

        public void addItem(ItemController item) {
            items.Add(item);
        }

        public void resetItems() {
            foreach(ItemController item in items) {
                item.reset();
            }
            items.Clear();
        }

        public void setAttr(bool CanFly, bool CanCarry, float Speed) {
            canFly = CanFly;
            canCarry = CanCarry;
            maxSpeed = Speed;
        }

        public void resetAttr() {
            maxSpeed = 7;
            canFly = false;
            canCarry = false;
            timer.setTimeRemaining(30);
        }

        public void changeAnimal(Animal.Type type) {
            GetComponent<HostTransformer>().setAnimal(type);
            getActiveComponents();
        }


        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}
