using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCompass : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public GameObject campssIcon;
    public GameObject groupIcon;
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
    private Image groupIconImage
    {
        get {
            if (this._groupIconImageCache == null) {
                this._groupIconImageCache = this.groupIcon.GetComponent<Image>();
            }
            return this._groupIconImageCache;
        }
    }
    private Image _groupIconImageCache;
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
        if (target == null || player == null || groupIcon == null) {
            return;
        }

        float distance = Vector3.Distance(target.transform.position, player.transform.position);
        campssIcon.SetActive(distance >= 14);

        Vector2 dir = this.target.transform.position - this.player.transform.position;
        // The magic of degree.
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - Mathf.Rad2Deg * 1.57f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, rotateSpeed * Time.deltaTime);

        this.groupIcon.transform.rotation = this.player.transform.rotation;
        groupIcon.SetActive(distance >= 14);
    }
}
