using UnityEngine;

public class SpaceBarRigidbody : MonoBehaviour {
    
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            gameObject.AddComponent(typeof(Rigidbody));
	}
}
