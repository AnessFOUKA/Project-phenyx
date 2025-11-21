using UnityEngine;
using UnityEngine.Splines;

public class FollowSplineNoRotation : MonoBehaviour
{
    public SplineContainer spline;
    public float t;

    void Update()
    {
        FollowSpline();
    }

    void FollowSpline()
    {
        // Récupère le spline principal
        var s = spline.Spline;

        // Position du spline
        Vector3 pos = SplineUtility.EvaluatePosition(s, t);

        transform.position = pos;
        // NE PAS faire : transform.rotation = ...
        // Donc l’objet garde sa rotation.
    }
}