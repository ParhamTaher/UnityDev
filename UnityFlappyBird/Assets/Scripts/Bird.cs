using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bird : MonoBehaviour {

    public Swipe swipeControls;
    public float upForce = 300f;
    public float touchStartTime = 0f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool isGliding = false;

    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;


    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        Physics2D.gravity = new Vector3(0, -12F, 0);
        SetColliderForSprite(0);

    }

    // Update is called once per frame
    void Update()
    {

        if (isDead == false) {
            

            if (Input.GetMouseButtonDown(0)) {

                touchStartTime = Time.time;
                anim.SetTrigger("Flap Down");
                SetColliderForSprite(1);
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
               

            } else if (Input.GetMouseButton(0)) {
                
                if (Time.time - touchStartTime > 0.2f) {
                    
                    isGliding = true;
                    anim.SetTrigger("Glide");
                    SetColliderForSprite(2);
                    rb2d.velocity = new Vector2(0f, -0.5f);
                    GameControl.instance.SetScrollSpeed(-6f);
                    GetComponent<ParticleSystem>().Play();

                }

            } else if (Input.GetMouseButtonUp(0)) {
                
                isGliding = false;
                anim.SetTrigger("Flap Up");
                SetColliderForSprite(0);
                GameControl.instance.SetScrollSpeed(-3f);
                touchStartTime = 0f;

            } else if (!isGliding) {
                
                anim.SetTrigger("Flap Up");
                GetComponent<ParticleSystem>().Stop();

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("Die 1");
        SetColliderForSprite(3);
        rb2d.velocity = Vector2.zero;
        isDead = true;
        GameControl.instance.BirdDied();
        GetComponent<ParticleSystem>().Stop();
    }

    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
}
