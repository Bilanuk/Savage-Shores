using UnityEngine;
using Unity.Netcode;
using TMPro;

public class BallTeleport : NetworkBehaviour
{
    public Transform teleportTransform;
    public TextMeshProUGUI blueScore;
    public TextMeshProUGUI redScore;

    public int BlueScore = 0;
    public int RedScore = 0;

    private void OnTriggerEnter(Collider other) {
        if (IsOwner) {
            if (other.gameObject.CompareTag("BlueGoal")){
                BlueScore++;
                blueScore.text = BlueScore.ToString();
            } else if (other.gameObject.CompareTag("RedGoal")){
                RedScore++;
                redScore.text = RedScore.ToString();
            } else {
                return;
            }

            transform.position = teleportTransform.position;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
