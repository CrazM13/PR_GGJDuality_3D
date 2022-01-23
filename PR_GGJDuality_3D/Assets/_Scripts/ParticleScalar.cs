using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScalar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parent;
    public GameObject particle;
    public ParticleSystem system;
    void Start()
    {
        particle = this.gameObject;
        parent = particle.transform.parent.gameObject;
        system = particle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var scaleShape = system.shape;
        scaleShape.scale = new Vector3(parent.transform.localScale.x, parent.transform.localScale.y, parent.transform.localScale.z);
    }
}
