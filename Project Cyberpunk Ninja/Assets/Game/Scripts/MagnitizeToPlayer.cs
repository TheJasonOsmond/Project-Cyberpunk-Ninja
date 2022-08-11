using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MoreMountains.TopDownEngine
{
    public class MagnitizeToPlayer : Magnetic
    {
        //Ensure TargetLayerMask is set to "Nothing"

        protected override void Initialization()
        {
            Reset();
        }

        private void Reset()
        {
            StopFollowing();
            _speed = 0f;
        }

    }
}