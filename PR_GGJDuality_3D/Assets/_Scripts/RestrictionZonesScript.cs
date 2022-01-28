using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictionZonesScript : MonoBehaviour
{
    [SerializeField]private GameObject parent;
    [SerializeField] private GameObject self;
    [SerializeField] private ParticleSystem selfParticle;
    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject;
        parent = self.transform.parent.gameObject;
        selfParticle = self.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var scaleShape = selfParticle.shape;
        scaleShape.scale = new Vector3(parent.transform.localScale.x, parent.transform.localScale.y, parent.transform.localScale.z);


    }

    
}
