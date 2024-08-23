using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleRotateControl : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject aim;
    [SerializeField] private GameObject center;

    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform centerRectTransform;
    [SerializeField] private RectTransform aimRectTransform;

    [SerializeField] private Vector3 startPosition;

    [SerializeField] public Transform transform_selectedGO;
    [SerializeField] private float rotatingSpeed = 1f;
    [SerializeField] private bool isRotating;

    [SerializeField] private Vector2 rotateVector;

    [SerializeField] private Vector3 startRotation;
    [SerializeField] private Vector3 endRotation;

    [SerializeField] private Quaternion startRotation_qua;
    [SerializeField] private Quaternion endRotation_qua;


    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        centerRectTransform =center.GetComponent<RectTransform>();
        aimRectTransform = aim.GetComponent<RectTransform>();

    }

    public void Update()
    {
        TryRotateObject();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        aim.SetActive(true);
        isRotating = true;
        startPosition= eventData.position;
        if (transform_selectedGO == null) return;
        startRotation = transform_selectedGO.rotation.eulerAngles;
        startRotation_qua = transform_selectedGO.rotation;

    }

    public void OnEndDrag(PointerEventData eventData) {

        aim.SetActive(false);
        isRotating = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerPos = eventData.position;
        Vector3 centerPosition = centerRectTransform.position;

        Vector2 delta = new Vector2(pointerPos.x - startPosition.x, pointerPos.y - startPosition.y);

        Vector2 deltaNormalize = new Vector2(delta.x / rectTransform.rect.width, delta.y / rectTransform.rect.height);
//        Debug.Log(deltaNormalize);
        aimRectTransform.anchoredPosition = delta;

        rotateVector = deltaNormalize;

    }

    public void TryRotateObject() {
        if (!isRotating) return;
        if (transform_selectedGO == null) return;
        Vector3 dragRotation = new Vector3(rotateVector.x , rotateVector.y, 0);

        //        endRotation = 50 *Vector3.Cross(Vector3.back, dragRotation);
        //        Quaternion tRot = Quaternion.RotateTowards (startRotation, endRotation);
        //        Debug.Log(tRot);
        //        transform_selectedGO.rotation = tRot;
        //        transform_selectedGO.Rotate(endRotation, rotatingSpeed * Time.deltaTime, Space.World);

        float rad = 50f;
        endRotation_qua = startRotation_qua * Quaternion.Inverse(startRotation_qua) * Quaternion.Euler(rad * rotateVector.y, -rad* rotateVector.x, 0) * startRotation_qua;

        transform_selectedGO.rotation = endRotation_qua;

    }
}
