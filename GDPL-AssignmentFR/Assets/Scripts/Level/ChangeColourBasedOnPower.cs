using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourBasedOnPower : MonoBehaviour
{
    private AimCannon cannonScript;

    public float transition;

    [SerializeField] public Material mat;

    public Color lowColour;

    public Color highColour;



    // Start is called before the first frame update
    void Start()
    {
        cannonScript = GameObject.FindGameObjectWithTag("Cannon").GetComponent<AimCannon>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transition = Mathf.Clamp01((float)cannonScript.GetPower() / (float)cannonScript.GetMaxPower());

        mat.color = Color.Lerp(lowColour , highColour, transition);

    }
}

