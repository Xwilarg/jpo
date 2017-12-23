using UnityEngine;

public class Burn : MonoBehaviour {

    private bool onFire;

    private void Start()
    {
        onFire = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!onFire)
        {
            GameObject fire = Instantiate(Resources.Load("Fire") as GameObject, transform.position, Quaternion.identity);
            fire.transform.parent = transform;
            onFire = true;
        }
    }
}
