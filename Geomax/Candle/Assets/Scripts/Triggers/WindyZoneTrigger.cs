using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

public class WindyZoneTrigger : BaseBoxTrigger
{
    [SerializeField][Min(0.0001f)] private float _impactDelay;

    [Inject] private PlayerEquipmentVisitor _equipmentVisitor;

    private CancellationTokenSource _actionCancellationToken;
    private bool _isStayIn;
    private bool _waiting;

    private void Start()
    {
        _actionCancellationToken = new CancellationTokenSource();
    }

    protected override void OnEnter(Collider other)
    {
        if (_waiting == true)
        {
            return;
        }

        if (other.TryGetComponent(out PlayerEquipment player))
        {
            MakeAction(player).Forget();
            _isStayIn = true;
        }
    }

    protected override void OnExit(Collider other)
    {
        if (other.GetComponent<PlayerEquipment>() != null)
        {
            _actionCancellationToken.Cancel();
            _isStayIn = false;
        }
    }

    private async UniTask MakeAction(PlayerEquipment player)
    {
        _waiting = true;

        await UniTask.Delay(TimeSpan.FromSeconds(_impactDelay));

        if (_isStayIn == true)
        {
            player.CurrentEquipment.Accept(_equipmentVisitor);
        }

        _waiting = false;
    }
}