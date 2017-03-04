using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCommands : MonoBehaviour {

    Vector3 originalPosition;

    void OnSelect()
    {
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    void OnReset()
    {
        var rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            DestroyImmediate(rigidbody);
        }

        this.transform.localPosition = originalPosition;
    }

    void OnDrop()
    {
        OnSelect();
    }


    // Use this for initialization
    void Start () {
        originalPosition = this.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
