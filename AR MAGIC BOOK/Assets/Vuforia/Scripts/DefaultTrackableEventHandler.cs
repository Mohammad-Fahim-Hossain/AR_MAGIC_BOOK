/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using System.Collections;
using System.Collections.Generic;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES
	GameObject obj1;
	GameObject obj2;
	GameObject obj3;
	GameObject obj4;
	GameObject obj5;
	GameObject obj6;
	GameObject obj7;



    protected TrackableBehaviour mTrackableBehaviour;

    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
		obj1 = GameObject.Find ("whale");
		obj2 = GameObject.Find ("Butterfly");
		obj3 = GameObject.Find ("shellcrab");
		obj4 = GameObject.Find ("cat");
		obj5 = GameObject.Find ("Dino");
		obj6 = GameObject.Find ("Dragon");
		obj7 = GameObject.Find ("Alien");

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;

		if (mTrackableBehaviour.Trackable.Name == "Whale_BG") {
			obj1.GetComponent<AudioSource> ().Play ();
		}
		if (mTrackableBehaviour.Trackable.Name == "Butterfly_BG") {
			obj2.GetComponent<AudioSource> ().Play ();
		}
		if (mTrackableBehaviour.Trackable.Name == "Carp_BG") {
			obj3.GetComponent<AudioSource> ().Play ();
		}
		if (mTrackableBehaviour.Trackable.Name == "Cat_BG") {
			obj4.GetComponent<AudioSource> ().Play ();
		}
		if (mTrackableBehaviour.Trackable.Name == "Dino_BG") {
			obj5.GetComponent<AudioSource> ().Play ();
		}
		if (mTrackableBehaviour.Trackable.Name == "Dragon_BG") {
			obj6.GetComponent<AudioSource> ().Play ();
		}
		if (mTrackableBehaviour.Trackable.Name == "Space_BG") {
			obj7.GetComponent<AudioSource> ().Play ();
		}

    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
		
		obj1.GetComponent<AudioSource> ().Stop ();
		obj2.GetComponent<AudioSource> ().Stop ();
		obj3.GetComponent<AudioSource> ().Stop ();
		obj4.GetComponent<AudioSource> ().Stop ();
		obj5.GetComponent<AudioSource> ().Stop ();
		obj6.GetComponent<AudioSource> ().Stop ();
		obj7.GetComponent<AudioSource> ().Stop ();
    }

    #endregion // PRIVATE_METHODS
}
