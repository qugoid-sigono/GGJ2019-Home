using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCompass : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public GameObject campssIcon;
    private Image compassIamge
    {
        get{
            if (this._campassImageCache == null) {
                this._campassImageCache = this.campssIcon.GetComponent<Image>();
            }
            return this._campassImageCache;
        }
    }
    private Image _campassImageCache;
    float initialAngle = 0;
    float rotateSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        GameObject uiCamera = GameObject.Find("CameraUI");

        if (target == null || player == null) {
            return;
        }

        Vector2 dir = this.target.transform.position - uiCamera.transform.position;
        this.initialAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null || player == null) {
            return;
        }

        float distance = Vector3.Distance(target.transform.position, player.transform.position);
        float alpha = distance >= 14 ? 1 : 0;
        compassIamge.color = new Color(1, 1, 1, alpha);

        Vector2 dir = this.target.transform.position - this.player.transform.position;
        // The magic of degree.
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - Mathf.Rad2Deg * 1.57f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
}
