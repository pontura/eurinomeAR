using UnityEngine;
using Vuforia;

public class VuforiaTargetInstantiator : DefaultObserverEventHandler
{
    public GameObject myModelPrefab;

    GameObject mMyModelObject;

    protected override void OnTrackingFound()
    {
        Debug.Log("Target Found");

        // Instantiate the model prefab only if it hasn't been instantiated yet
        if (mMyModelObject == null)
            InstantiatePrefab();

        base.OnTrackingFound();
    }

    void InstantiatePrefab()
    {
        if (myModelPrefab != null)
        {
            Debug.Log("Target found, adding content");
            mMyModelObject = Instantiate(myModelPrefab, mObserverBehaviour.transform);
            mMyModelObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            mMyModelObject.SetActive(true);
        }
    }
}