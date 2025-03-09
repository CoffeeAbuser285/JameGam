using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddPopup : MonoBehaviour
{
    private GameObject popupBox;
    private Animator _windowAnimator;
    private float _startTime;
    private float _targetTime;
    private bool _active;

    public TMP_Text _continueText;
    public GameObject visible;


    public void ShowAdd(float targetTime)
    {
        if (_active) return;
        _startTime = Time.time;
        _targetTime = Time.time + targetTime;
        _windowAnimator.SetBool("Open", true);
        _active = true;
        UpdateContinueText();
        visible.SetActive(true);
    }

    private void UpdateContinueText()
    {
        float timeLeftF = _targetTime - Time.time;
        int timeLeft = (int)timeLeftF;
        _continueText.text = $"Continue in {timeLeft}";
    }

    // Start is called before the first frame update
    void Start()
    {
        popupBox = gameObject;
        _windowAnimator = gameObject.GetComponent<Animator>();
        _windowAnimator.SetBool("Open", false);
        _active = false;
        visible.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // DEBUG
        // if (Time.time > 3.0f && Time.time < 5.0f && !_active) {
        //     Debug.Log("Showing Add");
        //     ShowAdd(5.0f);
        // }

        if (!_active) {
            if (_windowAnimator.GetCurrentAnimatorStateInfo(0).IsName("AddIdle")) {
                // Debug.Log("Make invisible");
                visible.SetActive(false);
                return;
            }
        };

        UpdateContinueText();
        float timeLeft = _targetTime - Time.time;
        if (timeLeft <= 0.0) {
            // Debug.Log("Time expired");
            _windowAnimator.SetBool("Open", false);
            _active = false;
        }
    }
}
