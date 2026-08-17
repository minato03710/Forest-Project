using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhotoCamera : MonoBehaviour
{
    [Header("Camera")]
    public Camera playerCamera;

    [Header("Detection")]
    public float detectionDistance = 50f;

    [Header("Target UI")]
    public GameObject targetInfo;
    public TMP_Text targetNameText;
    public TMP_Text scoreText;

    private PhotoTarget currentTarget;
    [Header("Photo Effect")]
    public GameObject photoFlash;
    public float flashDuration = 0.1f;

    void Start()
    {
        if (targetInfo != null)
        {
            targetInfo.SetActive(false);
        }
        if (photoFlash != null)
        {
            photoFlash.SetActive(false);
        }
    }

    void Update()
    {
        if (Time.timeScale == 0f)
            return;

        DetectTarget();

        if (Mouse.current != null &&
            Mouse.current.rightButton.wasPressedThisFrame)
        {
            TakePhoto();
        }
    }

    void DetectTarget()
    {
        Ray ray = playerCamera.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f)
        );

        RaycastHit hit;

        if (Physics.Raycast(
            ray,
            out hit,
            detectionDistance
        ))
        {
            PhotoTarget target =
                hit.collider.GetComponent<PhotoTarget>();

            if (target != null)
            {
                currentTarget = target;

                if (targetInfo != null)
                {
                    targetInfo.SetActive(true);
                }

                if (targetNameText != null)
                {
                    targetNameText.text =
                        target.GetTargetName();
                }

                if (scoreText != null)
                {
                    scoreText.text =
                        "+" + target.GetScore();
                }

                return;
            }
        }

        currentTarget = null;

        if (targetInfo != null)
        {
            targetInfo.SetActive(false);
        }
    }

    void TakePhoto()
    {
        if (currentTarget == null)
        {
            Debug.Log("No target detected.");
            return;
        }

        if (!currentTarget.CanTakePhoto())
        {
            Debug.Log(
                currentTarget.GetTargetName() +
                " has already been photographed."
            );

            return;
        }

        int photoScore = currentTarget.GetScore();

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(photoScore);
        }

        currentTarget.Photograph();

        Debug.Log(
            "Photo taken: " +
            currentTarget.GetTargetName()
        );

        Debug.Log(
            "Earned: +" +
            photoScore
        );
        //Flash photography
        StartCoroutine(PhotoFlashEffect());
    }
IEnumerator PhotoFlashEffect()
    {
        if (photoFlash == null)
            yield break;

        photoFlash.SetActive(true);

        yield return new WaitForSeconds(flashDuration);

        photoFlash.SetActive(false);
    }


}




