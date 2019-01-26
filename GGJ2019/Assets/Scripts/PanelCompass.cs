using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCompass : MonoBehaviour
{
    GameObject target;
    GameObject player;
    float initialAngle = 0;
    float rotateSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Home");
        player = GameObject.Find("Player");

        GameObject uiCamera = GameObject.Find("CameraUI");

        Vector2 dir = this.target.transform.position - uiCamera.transform.position;
        this.initialAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null && player == null) {
            return;
        }

        Vector2 dir = this.target.transform.position - this.player.transform.position;
        // The magic of degree.
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - Mathf.Rad2Deg * 1.57f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
}
