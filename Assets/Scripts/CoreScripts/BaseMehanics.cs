using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseMehanics : MonoBehaviour {

    #region AnimValues
    public float animTime;
    public float animSpeed;


    private bool wasStamped;
    public bool startAnim=false;
    #endregion

    #region Components
    [HideInInspector]
    public Animation anim;
    [HideInInspector]
    public AnimationState state;
    [HideInInspector]
    public MeshRenderer meshRenderer;
    [HideInInspector]
    public BoxCollider boxCollider;
    [HideInInspector]
    public MeshCollider meshCollider;
    #endregion

    public bool visible;
    public bool trigger = false; 


    // Use this for initialization
    void Awake ()
    {
        Init();
	}

    void Init()
    {
        anim = GetComponent<Animation>();
        if (anim == null)
        {
            gameObject.AddComponent<Animation>();
            anim = GetComponent<Animation>();
        }
        anim.playAutomatically = false;

        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            gameObject.AddComponent<MeshRenderer>();
            meshRenderer = GetComponent<MeshRenderer>();
        }
        if (GetComponent<BoxCollider>())
            boxCollider = GetComponent<BoxCollider>();

        if (GetComponent<MeshCollider>())
            meshCollider = GetComponent<MeshCollider>();

        //    boxCollider.isTrigger = trigger;
        //if (boxCollider == null)
        //{
        //    gameObject.AddComponent<BoxCollider>();
        //    boxCollider = GetComponent<BoxCollider>();
        //}
        //meshRenderer.enabled = visible;
        //visible = meshRenderer.enabled;
        //trigger = boxCollider.isTrigger;

        InitAnimation();
    }

    void InitAnimation()
    {
        foreach (AnimationState state in anim)
        {
            state.normalizedTime = 0f;
            animSpeed = state.normalizedSpeed;
        }
        startAnim = false;
        //anim.Play();
    }


    private int interval = 3;
    // Update is called once per frame
    void Update ()
    {
        if (Time.frameCount % interval == 0)
        {
            Tick();
            UpdateAnim();
        }
        //else if(Time.frameCount % 20 == 0)
        {
            UpdateInput();
        }

        
	}

    void UpdateAnim()
    {

        if (startAnim)
        {
            if(animSpeed>=0)
            {
                if (animTime < 1)
                {
                    animTime += Time.deltaTime * animSpeed;
                }
                else if (animTime >= 1)
                {
                    animTime = 1;
                    wasStamped = true;
                    startAnim = false;
                }
            }
            
            else
            {
                if (animTime > 0)
                    animTime += Time.deltaTime * animSpeed;

                if (animTime <= 0)
                {
                    animTime = 0;
                    wasStamped = true;
                    startAnim = false;
                }
            }
            
          //  Debug.Log(gameObject.name + " : " +  animTime);
        }
    }

    void Tick()
    {
        foreach (AnimationState state in anim)
        {
            state.normalizedTime = animTime;
            //state.normalizedSpeed = animSpeed/2;
            //animSpeed = state.normalizedSpeed;
            //Debug.Log(state.normalizedSpeed);
        }
    }

    public void SetVisible(bool visible)
    {
        if(meshRenderer)
            meshRenderer.enabled = visible;
    }
    public void SetColliderOnTrigger(bool value)
    {
        if(boxCollider)
            boxCollider.isTrigger = value;
        else if (meshCollider)
            meshCollider.isTrigger = value;
    }

    public void Stamp(float value = 1f)
    {
        if (anim == null)
        {
            return;
        }
        if (!WasStamped())
        {
            startAnim = true;
            animSpeed = value;
            anim.Play();
            anim.wrapMode = WrapMode.ClampForever;
        }
    }
    public bool WasStamped()
    {
        return wasStamped;
    }

    public void MoveTowards(float target, float moveSpeed=1f)
    {
        this.animTime = Mathf.MoveTowards(this.animTime, 0f, Time.deltaTime * moveSpeed);

    }

    void UpdateInput()
    {
        //meshRenderer.enabled = visible;
        //boxCollider.isTrigger = trigger;

        //TODO: mouse drag and change animavalue
    }
    public Element interact;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Element>())
        {
            interact = other.GetComponent<Element>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Element>())
        {
            interact = null;
        }
    }


}

