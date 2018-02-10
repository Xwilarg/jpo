using UnityEngine;

public class GiveFeedback : MonoBehaviour {

	public enum feedbackLevel
    {
        BAD,
        AVERAGE,
        GOOD
    }

    public feedbackLevel lvl;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<NetworkManager>()
            .sendDatas("FEED" + (int)lvl);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
    }
}
