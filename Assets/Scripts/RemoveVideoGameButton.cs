using UnityEngine;

public class RemoveVideoGameButton : MonoBehaviour {

    public GameObject buttonVideoGame;
    private teleport tp;

    private void Start()
    {
        tp = GetComponent<teleport>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Camera (eye)" || other.name == "Controller (left)" || other.name == "Controller (right)")
        {
            if (tp.newRoom.name == "JeuVidéo")
                buttonVideoGame.SetActive(false);
        }
    }
}
