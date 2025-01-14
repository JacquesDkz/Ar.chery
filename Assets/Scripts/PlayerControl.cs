using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhanceTouch = UnityEngine.InputSystem.EnhancedTouch;



public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text _debugConsole;

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits;
    private static int _counter = 0;
    private Transform _cameraTransform;
    private GameObject _currentArrow;

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();
        _cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        EnhanceTouch.TouchSimulation.Enable();
        EnhanceTouch.EnhancedTouchSupport.Enable();
        EnhanceTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhanceTouch.TouchSimulation.Disable();
        EnhanceTouch.EnhancedTouchSupport.Disable();
        EnhanceTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhanceTouch.Finger finger)
    {
        ControlType controlType = gameManager.GetControlType();

        if (finger.index != 0) return;

        switch (controlType)
        {
            case ControlType.PLACEMENT:
                PlaceObjectAt(finger);
                VisualDebug.Console.Log("Objet placé numéro : " + _counter);
                break;

            case ControlType.SHOOT:
                _currentArrow = Shoot(finger);
                VisualDebug.Console.Log("Flèche tirée");
                break;

            default:
                break;
        }
    }

    private void PlaceObjectAt(EnhanceTouch.Finger finger)
    {
        
        Pose pose;
        if (raycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hits)
            {
                pose = hit.pose;
                Instantiate(targetPrefab, pose.position, pose.rotation * UnityEngine.Quaternion.Euler(0, 180, 0));
                _counter++;
            }
        }
    }

    private GameObject Shoot(EnhanceTouch.Finger finger)
    {
        return Instantiate(arrowPrefab, _cameraTransform.position, _cameraTransform.rotation);
    }

    public static int getCounter()
    { return _counter; }

}
