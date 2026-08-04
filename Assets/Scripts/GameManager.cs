using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    [SerializeField] private BallLauncher launcher;
    [SerializeField] private Rigidbody ball;
    [SerializeField] private Trajectory trajectory;

    [Header("Course")]
    [SerializeField] private Transform[] launchPoints;
    [SerializeField] private int[] pars;

    [Header("UI")]
    [SerializeField] private ShotsUI shotsUI;
    [SerializeField] private ResultUI resultUI;

    public bool GameFinished { get; private set; }

    public int CurrentHole { get; private set; }

    public int ShotsTaken { get; private set; }

    public int CurrentPar => pars[CurrentHole];

    private BallController ballController;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ballController = ball.GetComponent<BallController>();

        CurrentHole = 0;
        ShotsTaken = 0;
        GameFinished = false;

        launcher.SetCurrentBall(ball);

        if (trajectory != null)
            trajectory.HideTrajectory();

        SpawnAtCurrentHole();
    }

    private void SpawnAtCurrentHole()
    {
        ball.linearVelocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        ball.position = launchPoints[CurrentHole].position;
        ball.rotation = launchPoints[CurrentHole].rotation;

        ballController.ResetState();

        launcher.SetCurrentBall(ball);

        shotsUI.UpdateHole(CurrentHole + 1);
        shotsUI.UpdateShots(0);

        ShotsTaken = 0;

        CameraFollow.Instance.SnapToBall();
    }

    public void UseShot()
    {
        if (GameFinished)
            return;

        ShotsTaken++;

        shotsUI.UpdateShots(ShotsTaken);
    }

    public void HoleCompleted()
    {
        if (GameFinished)
            return;

        resultUI.ShowHoleResult(
            CurrentHole + 1,
            ShotsTaken,
            CurrentPar);

        Invoke(nameof(NextHole), 2f);
    }

    private void NextHole()
    {
        resultUI.HideResult();

        CurrentHole++;

        if (CurrentHole >= launchPoints.Length)
        {
            FinishGame();
            return;
        }

        SpawnAtCurrentHole();
    }

    private void FinishGame()
    {
        GameFinished = true;

        resultUI.ShowCourseComplete();
    }

    public void ResetBall()
    {
        ball.linearVelocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;

        ball.position = launchPoints[CurrentHole].position;
        ball.rotation = launchPoints[CurrentHole].rotation;

        ballController.ResetState();

        launcher.SetCurrentBall(ball);

        if (trajectory != null)
            trajectory.HideTrajectory();

        CameraFollow.Instance.SnapToBall();
    }
}