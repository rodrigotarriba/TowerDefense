using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Health;
using TowerDefense.Affectors;
using TowerDefense.Towers;
using Core.Health;
using TowerDefense.Nodes;
using System;
using TowerDefense.Targetting;
namespace TowerDefense.Agents{
public class PlayerAttackAgent : Agent
{
        public override Vector3 position => base.position;

        public override Vector3 velocity => base.velocity;

        protected override bool isPathBlocked => base.isPathBlocked;

        protected override bool isAtDestination => base.isAtDestination;

        protected Targetter targettingScr;

        List<GameObject> listOfTargets;

        public AttackAffectorPlayer attacking;

        public PlayerTest player;
        protected bool m_IsAttacking;

        protected PlayerTest m_TargetTower;
        
        

        protected override void OnPartialPathUpdate()
        {
            if (!isPathBlocked)
			{
				state = State.OnCompletePath;
				return;
			}
            attacking.towerTargetter.transform.position = m_NavMeshAgent.pathEndPosition;
            player = GetClosestTower();
            
            attacking.towerTargetter.transform.position = m_NavMeshAgent.pathEndPosition;
			PlayerTest tower = GetClosestTower();
			if (tower != m_TargetTower)
			{
				// if the current target is to be replaced, unsubscribe from removed event
				if (m_TargetTower != null)
				{
					m_TargetTower.removed -= OnTargetTowerDestroyed;
				}
				
				// assign target, can be null
				m_TargetTower = tower;
				
				// if new target found subscribe to removed event
				if (m_TargetTower != null)
				{
					m_TargetTower.removed += OnTargetTowerDestroyed;
				}
			}
			if (m_TargetTower == null)
			{
				return;
			}
			float distanceToTower = Vector3.Distance(transform.position, m_TargetTower.transform.position);
			if (!(distanceToTower < attacking.towerTargetter.effectRadius))
			{
				return;
			}
			if (!attacking.enabled)
			{
				attacking.towerTargetter.transform.position = transform.position;
				attacking.enabled = true;
			}
			state = State.Attacking;
			m_NavMeshAgent.isStopped = true;
            
            
        }

        protected override void LazyLoad()
		{
			base.LazyLoad();
			if (attacking == null)
			{
				attacking = GetComponent<AttackAffectorPlayer>();
			}
		}

        private PlayerTest GetClosestTower()
        {
            if (attacking.towerTargetter.GetTarget().gameObject.tag == "Player")
            {
                Debug.Log("player found");
            }
            var towerController = attacking.towerTargetter.GetTarget() as PlayerTest;
			return towerController;
        }

        public override void Remove()
		{
			base.Remove();
			if (m_TargetTower != null)
			{
				m_TargetTower.removed -= OnTargetTowerDestroyed;
			}
			attacking.enabled = false;
			m_TargetTower = null;
		}

        protected override void PathUpdate()
        {
            switch (state)
			{
				case State.OnCompletePath:
					OnCompletePathUpdate();
					break;
				case State.OnPartialPath:
					OnPartialPathUpdate();
					break;
				case State.Attacking:
					AttackingUpdate();
					break;
			}

            

        }

        protected virtual void OnTargetTowerDestroyed(DamageableBehaviour tower)
		{
			if (m_TargetTower == tower)
			{
				m_TargetTower.removed -= OnTargetTowerDestroyed;
				m_TargetTower = null;
			}
		}

        protected void AttackingUpdate()
		{
			if (player != null)
			{
				return;
			}
			MoveToNode();

			// Resume path once blocking has been cleared
			m_IsAttacking = false;
			m_NavMeshAgent.isStopped = false;
			attacking.enabled = false;
			state = isPathBlocked ? State.OnPartialPath : State.OnCompletePath;
			// Move the Targetter back to the agent's position
			attacking.towerTargetter.transform.position = transform.position;
		}

        //this enemy strictly attacks the player, attempting to stop them from killing other enemies
        // Start is called before the first frame update


    }

}
