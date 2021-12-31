using System.Collections.Generic;
using UnityEngine;

namespace FriedSynapse.FlowEnt.Builder
{
    public class PlaygroundController : MonoBehaviour
    {
#pragma warning disable RCS1169, IDE0044
        [SerializeField]
        private List<Transform> objects;
        private List<Transform> Objects => objects;
#pragma warning restore RCS1169, IDE0044

#pragma warning disable IDE0051, RCS1213
        private void Start()
        {
            Objects[0].Echo().MoveTowardsElastic(Objects[1], 3).LookAt(Objects[1]).Start();
            new Echo().SetName("Update").Debug().Start();
            new Echo().SetName("Smooth Update").SetUpdateType(UpdateType.SmoothUpdate).Debug().Start();
            new Echo().SetName("Late Update").SetUpdateType(UpdateType.LateUpdate).Debug().Start();
            new Echo().SetName("Smooth Late Update").SetUpdateType(UpdateType.SmoothLateUpdate).Debug().Start();
            new Echo().SetName("Fixed Update").SetUpdateType(UpdateType.FixedUpdate).Debug().Start();
        }

        private void OnDrawGizmos()
        {
        }
#pragma warning restore IDE0051, RCS1213
    }
}