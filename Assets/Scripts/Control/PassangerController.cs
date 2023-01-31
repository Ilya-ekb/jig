using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class PassangerController : MonoBehaviour
{
    public enum WanderStates { NoPointDesignated, WalkingToPoint, IdleOnPoint };
    public Passanger MyPassanger;
    public WanderStates WanderState;

    public UnityEvent NewPointDesignatedEvent;
    public UnityEvent ArrivedOnPointEvent;
    public UnityEvent FinishedIdlingEvent;

    [SerializeField] private TicketSettings MyTicketSettings;

    private float IdleWalkingWaitTime;
    private float PointStartWaitTime;
    private Vector3 DesignatedMovePoint;
    private Quaternion DesignatedMoveRotation;
    private NavMeshAgent Agent;

    /*private void Start()
    {
        // временное решение
        Initialize();
    }*/

    public void Initialize () {
        MyPassanger = new Passanger(Passanger.PassangerStates.IdleWalking, MyTicketSettings);
        WanderState = WanderStates.NoPointDesignated;
        Agent = GetComponent<NavMeshAgent> ();
        Agent.updatePosition = true;
        Agent.updateRotation = true;
    }

    private void Update()
    {
        UpdateAI();
    }

    public void ExitFromTrain()
    {
        ChangePassangerState(Passanger.PassangerStates.GoingToExit);
    }

    public void ChangePassangerState(Passanger.PassangerStates state)
    {
        MyPassanger.PassangerState = state;
        WanderState = WanderStates.NoPointDesignated;
    }


    void NewPointDesignated() {
        NewPointDesignatedEvent.Invoke();
    }

    void ArrivedOnPoint()
    {
        ArrivedOnPointEvent.Invoke();
        if (MyPassanger.PassangerState == Passanger.PassangerStates.GoingToSit)
        {
            MyPassanger.PassangerState = Passanger.PassangerStates.Sitting;
            return;
        }
        //MyPassanger.PassangerState = (Passanger.PassangerStates) Random.Range (0, MyPassanger.GetStateCount ());
        //WanderState = WanderStates.WalkingToPoint;
    }



    public void ForceChangePoint(Vector3 point)
    {
        Agent.SetDestination(point);
        DesignatedMovePoint = point;
        WanderState = WanderStates.WalkingToPoint;
    }
    public void ForceChangePoint(Vector3 point, Quaternion rotation)
    {
        Agent.SetDestination(point);
        DesignatedMovePoint = point;
        DesignatedMoveRotation = rotation;
        WanderState = WanderStates.WalkingToPoint;
    }




    public void ForceChangeDestination(Passanger.PassangerStates state)
    {
        MyPassanger.PassangerState = state;
        WanderState = WanderStates.NoPointDesignated;
    }

    void FinishedIdling()
    {
        FinishedIdlingEvent.Invoke();
    }
    void UpdateAI()
    {
        switch (WanderState)
        {
            case WanderStates.WalkingToPoint:

                if (Agent.remainingDistance < Config.PassengerStopDistance)
                {
                    WanderState = WanderStates.IdleOnPoint;
                    ArrivedOnPoint ();
                }
                PointStartWaitTime = Time.time;

                if (MyPassanger.PassangerState == Passanger.PassangerStates.IdleWalking)
                {
                    IdleWalkingWaitTime = Time.time + Random.Range (Config.PassengerMinWanderPointWaitTime, Config.PassengerMaxWanderPointWaitTime);
                }
                break;
            case WanderStates.IdleOnPoint:

                //Придумать что сделать с вращением
                transform.rotation = Quaternion.Lerp (transform.rotation, DesignatedMoveRotation, Config.PassengerRotationLerp);

                if (MyPassanger.PassangerState == Passanger.PassangerStates.IdleWalking)
                {

                    if (Time.time > IdleWalkingWaitTime)
                    {
                        WanderState = WanderStates.NoPointDesignated;
                        FinishedIdling ();
                    }
                }
                break;
            default:

                PointStartWaitTime = -1;

                if (MyPassanger.PassangerState == Passanger.PassangerStates.GoingToSit)
                {
                    //Переместить название папки точек в staticdata или config
                    GameObject sitPoints = GameObject.Find (Config.sitPointsFolderName);
                    Transform point = sitPoints.transform.GetChild (Random.Range (0, sitPoints.transform.childCount));

                    DesignatedMovePoint = point.position;
                    DesignatedMoveRotation = point.rotation;
                }
                else if (MyPassanger.PassangerState == Passanger.PassangerStates.IdleWalking)
                {
                    //Переместить название папки точек в staticdata или config
                    GameObject wanderPoints = GameObject.Find (Config.wanderPointsFolderName);
                    Transform point = wanderPoints.transform.GetChild (Random.Range (0, wanderPoints.transform.childCount));

                    DesignatedMovePoint = point.position;
                    DesignatedMoveRotation = point.rotation;
                }
                else if (MyPassanger.PassangerState == Passanger.PassangerStates.GoingToExit)
                {
                    //Переместить название папки точек в staticdata или config
                    GameObject exitPoints = GameObject.Find (Config.exitPointsFolderName);
                    Transform point = exitPoints.transform.GetChild (Random.Range (0, exitPoints.transform.childCount));

                    DesignatedMovePoint = point.position;
                    DesignatedMoveRotation = point.rotation;
                }

                Agent.SetDestination (DesignatedMovePoint);

                WanderState = WanderStates.WalkingToPoint;
                NewPointDesignated ();
                break;
        }
    }
}