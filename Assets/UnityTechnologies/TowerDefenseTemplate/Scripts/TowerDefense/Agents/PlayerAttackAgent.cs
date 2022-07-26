using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Health;
using TowerDefense.Affectors;
using TowerDefense.Towers;
using Core.Health;
using TowerDefense.Nodes;

namespace TowerDefense.Agents{
public class PlayerAttackAgent : Agent
{
        public override Vector3 position => base.position;

        public override Vector3 velocity => base.velocity;

        protected override bool isPathBlocked => base.isPathBlocked;

        protected override bool isAtDestination => base.isAtDestination;

        //this enemy strictly attacks the player, attempting to stop them from killing other enemies
        // Start is called before the first frame update

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object other)
        {
            return base.Equals(other);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void TakeDamage(float damageValue, Vector3 damagePoint, IAlignmentProvider alignment)
        {
            base.TakeDamage(damageValue, damagePoint, alignment);
        }

        protected override void Kill()
        {
            base.Kill();
        }

        public override void SetNode(Node node)
        {
            base.SetNode(node);
        }

        public override void Remove()
        {
            base.Remove();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void GetNextNode(Node currentlyEnteredNode)
        {
            base.GetNextNode(currentlyEnteredNode);
        }

        public override void MoveToNode()
        {
            base.MoveToNode();
        }

        public override void HandleDestinationReached()
        {
            base.HandleDestinationReached();
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void NavigateTo(Vector3 nextPoint)
        {
            base.NavigateTo(nextPoint);
        }

        protected override void LazyLoad()
        {
            base.LazyLoad();
        }

        protected override void OnCompletePathUpdate()
        {
            base.OnCompletePathUpdate();
        }

        protected override void PathUpdate()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnPartialPathUpdate()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
        }

}

}
