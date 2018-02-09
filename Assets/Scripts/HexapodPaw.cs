using UnityEngine;

public class HexapodPaw : MonoBehaviour {

    private void Update()
    {
        transform.Rotate(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
    }
}
