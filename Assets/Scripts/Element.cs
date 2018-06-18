using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    #region AnimValues
    [Range(0,1)]
   // [HideInInspector]
    public float animValue=0F;
    [HideInInspector]
    public float targetValue;
    [HideInInspector]
    public WrapMode wrapMode;
    [HideInInspector]
    public bool wasStamped=false;
    [HideInInspector]
    public bool stamp = false;
    [HideInInspector]
    public float timer = 1;
    #endregion

    #region Actions
    [HideInInspector]
    public bool isVisible = true;
    //[HideInInspector]
    //public bool isTrigger = false;
    [HideInInspector]
    public bool isActive = true;
    [HideInInspector]
    public bool canInteract = true;
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
    [HideInInspector]
    public CapsuleCollider capsuleCollider;
    [HideInInspector]
    public SphereCollider sphereCollider;
    #endregion

    public string _name;
    public int _index;


    // Use this for initialization
    void Start () {

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
        anim.wrapMode = WrapMode.ClampForever;

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

        if (GetComponent<CapsuleCollider>())
            capsuleCollider = GetComponent<CapsuleCollider>();

        if (GetComponent<SphereCollider>())
            sphereCollider = GetComponent<SphereCollider>();

        if (GetComponent<Camera>())
        {
            GetComponent<Camera>().enabled = false;
            GetComponent<Camera>().cullingMask = 1 << 0;
        }


    }

	// Update is called once per frame
	void Update ()
    {

        Tick();
        ForStamp();
        SetActions();
        //if (isInteract)
        //{
            
        //}
    }

    void SetActions()
    {
        //meshRenderer.enabled = isVisible;
        gameObject.SetActive(isActive);

        if (meshCollider)
        {
            //meshCollider.isTrigger = isTrigger;
            meshCollider.enabled = canInteract;
        }
        else if (boxCollider)
        {
            //boxCollider.isTrigger = isTrigger;
            boxCollider.enabled = canInteract;
        }
        else if (capsuleCollider)
        {
            //capsuleCollider.isTrigger = isTrigger;
            capsuleCollider.enabled = canInteract;
        }
        else if (sphereCollider)
        {
            //sphereCollider.isTrigger = isTrigger;
            sphereCollider.enabled = canInteract;
        }

    }
    public int stampMaterial = 0;
    Color startColor;

    void ForStamp()
    {
        if (stamp && timer > 0)
        {
            foreach (AnimationState state in anim)
            {
                animValue += Time.deltaTime * timer;
                state.normalizedTime = animValue;

                Color c = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g-100f, meshRenderer.material.color.b-200f, meshRenderer.material.color.a);

                if (stampMaterial == -1)
                    meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, c, Time.deltaTime/100);
                

                if (animValue >= 1)
                {
                    stamp = false;
                    animValue = 1f;
                    wasStamped = true;
                }

            }
        }
        else if (stamp && timer < 0)
        {
            foreach (AnimationState state in anim)
            {
                animValue = Mathf.MoveTowards(animValue, timer, -timer * Time.deltaTime);
                state.normalizedTime = animValue;

                Color c = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g + 100f, meshRenderer.material.color.b + 200f, meshRenderer.material.color.a);

                if (stampMaterial == -1)
                    meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, c, Time.deltaTime / 100);

                if (animValue <= 0)
                {
                    stamp = false;
                    animValue = 0f;
                }

            }
        }

        foreach (AnimationState state in anim)
        {
            state.normalizedTime = animValue;
            if (animValue == 1f)
            {
                anim.Play();
            }
        }

        if (wrapMode == WrapMode.Loop)
        {
            if (animValue == 1)
                animValue = 0;
            else if (animValue < 0f)
                animValue = .99999f;

            anim.wrapMode = WrapMode.Loop;
        }
    }


    void Tick()
    {
        if (animValue > 1)
            animValue = 1;
        else if (animValue < 0)
            animValue = 0;

        foreach (AnimationState state in anim)
        {
            state.normalizedTime = animValue;
        }
    }


    [HideInInspector]
    public bool isInteract = false;
    Vector3 startPos = Vector3.zero;
    Vector3 endPos = Vector3.zero;
    [HideInInspector]
    public float angleFromStart;
    public enum ElementMove
    {
        x, y
    };
    [HideInInspector]
    public ElementMove elementMove;



    private void OnMouseDown()
    {
        if (!canInteract)
            return;
        isInteract = true;
       // Debug.Log(gameObject.name + " :  " + isInteract);
        startPos = Input.mousePosition - transform.position;

    }

    private void OnMouseDrag()
    {
        if (!canInteract)
            return;
        endPos = Input.mousePosition - transform.position;
        angleFromStart = Vector3.Angle(startPos, endPos);

        // angleFromStart = endPos - startPos;
        //  Debug.Log(angleFromStart);

        //transform.rotation.SetLookRotation(Camera.main.WorldToScreenPoint(Input.mousePosition));
     if (elementMove == ElementMove.y)
        {
            //transform.position = initialPosition;
            angleFromStart = endPos.y - startPos.y;
            angleFromStart /= 100;
            //Debug.Log("Move Y:  " + angleFromStart);

            //Level.MoveTowards(gameObject.GetComponent<Element>(), angleFromStart);
            //animValue = angleFromStart + animValue;
            
        }
        else if (elementMove == ElementMove.x)
        {
            //transform.position = initialPosition;
            angleFromStart = endPos.x - startPos.x;
            angleFromStart /= 100;
            //
            //Debug.Log("Move X:  " + angleFromStart);
        }
    }

    private void OnMouseUp()
    {
        if (!canInteract)
            return;
        isInteract = false;
        //Debug.Log(gameObject.name + " :  " + isInteract);
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
