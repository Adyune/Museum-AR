using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AR_Audio_Control : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    AudioSource audioPlay;
    GameObject rabbit;
    Animation rabbitAnim;
    //GameObject dude;
    //Animation dudeAnim;
    //Animation rabbitAnim;
    // Start is called before the first frame update
    void Start()
    {
        audioPlay = GetComponent<AudioSource>();
        rabbit = transform.Find("rabbitFixed").gameObject; //transform.Find("rabbitTurnTable").gameObject;
        rabbitAnim = rabbit.GetComponent<Animation>();
        //dude = transform.Find("Dude_Swing_Dancing").gameObject;
        //dudeAnim = dude.GetComponent<Animation>();
        //mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            audioPlay.Play();
            rabbitAnim.Play();
            //dudeAnim.Play();
        }
        else
        {
            // Stop audio when target is lost
            audioPlay.Pause();
            rabbitAnim.Stop();
            //dudeAnim.Stop();
        }
    }
}
