using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;

[BurstCompile]
public partial struct MovingSystem : ISystem
{
    [BurstCompile]
    public readonly void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        JobHandle jobHandle = new MoveJob
        {
            DeltaTime = deltaTime
        }.ScheduleParallel(state.Dependency);

        jobHandle.Complete();

        new TestIsInRangeJob
        {
            // TODO - params?
        }.Run();
    }
}

[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float DeltaTime;

    [BurstCompile]
    public readonly void Execute(MoveToPlayerAspect moveToPlayerAspect)
    {
        moveToPlayerAspect.Move(DeltaTime);
    }
}

[BurstCompile]
public partial struct TestIsInRangeJob : IJobEntity
{
    [BurstCompile]
    public readonly void Execute(MoveToPlayerAspect moveToPlayerAspect)
    {
        moveToPlayerAspect.TestIsInRange();
    }
}
