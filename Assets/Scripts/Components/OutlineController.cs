using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class OutlineController : MonoBehaviour
{
    private Outline outline;
    private GlowEffect glowEffect;
    private Material material;
    public TextMesh mesh;
    public bool isConfirm;
    public Material glowYellow;
    public Material defaultMat;
    // Start is called before the first frame update
    void Start()
    {
        
        outline = this.GetComponent<Outline>();
        glowEffect = this.GetComponent<GlowEffect>();
        material = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateOutline()
    {
        material.color = new Vector4(0.7f, 0.7f, 0.7f, 1);
    }

    public void OutlineSetColor(int i)
    {
        outline.color = i;
    }

    public void DeleteOutline()
    {
        if (!isConfirm)
        {
            material.color = new Vector4(1f, 1f, 1f, 1);
        }
        
    }

    public void ButtonPressed()
    {
        material.color = new Vector4(0.4f, 0.4f, 0.4f, 1);
        mesh.color = Color.white;
        
    }

    public void ButtonRelease()
    {
        if (!isConfirm)
        {
            material.color = new Vector4(0.7f, 0.7f, 0.7f, 1);
            mesh.color = Color.black;

        }
    }

    public void OutlineOn()
    {
        if(outline == null)
        {
            outline = this.gameObject.AddComponent<Outline>();
        }
    }

    public void OutlineOff()
    {
        DestroyImmediate(this.gameObject.GetComponent<Outline>());
        outline = null;
    }

    public void GlowEffectOn()
    {
        //if(glowEffect == null)
        //{
        //    glowEffect = this.gameObject.AddComponent<GlowEffect>();
        //}
        Debug.Log("Material change");
        this.GetComponent<Renderer>().material = glowYellow;
    }

    public void GlowEffectOff()
    {
        //DestroyImmediate(this.gameObject.GetComponent<GlowEffect>());
        //glowEffect = null;
        this.GetComponent<Renderer>().material = defaultMat;
    }
}
