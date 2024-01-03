using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public readonly partial struct MoveToPlayerAspect : IAspect
{
    private readonly RefRW<LocalTransform> _localTransform;
    private readonly RefRO<Speed> _speed;

    // TODO - player pos
    // private readonly RefRW<PlayerPosition> _playerPosition;

    public void Move(float deltaTime)
    {
        _localTransform.ValueRW.Position += new float3(deltaTime * _speed.ValueRO.Value, 0, 0);
    }

    public void TestIsInRange()
    {
        /*float inRangeDist = 10f;
        if(math.distancesq(_localTransform.ValueRO.Position, _playerPosition.ValueRO.Position) < inRangeDist)
        {
            // shoot or idk
        }*/
    }
}
