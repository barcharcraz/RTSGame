﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using Units;
using Commands;


public class UnitController : BasicController
{


    public virtual void Update()
    {
        //base.Update();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            if (agent.hasPath)
            {
                setMoving(true);
            }
            else
            {
                setMoving(false);
            }
        }
    }
    public override void OnIssueCommand(Vector3 pos)
    {
        CommandManager mgr = GetComponent<CommandManager>();
        mgr.AddCommandNow(new MoveTo(mgr, pos));
    }


    ///-------------------------------------------------------------------------------------------------
    /// <summary>  Moves this unit to position <paramref name="pos"/> and stops
    ///            once the unit is within <paramref name="deltad"/> of <paramref name="pos"/> </summary>
    ///
    /// <remarks>   Charlie, 1/30/2013. </remarks>
    ///
    /// <param name="pos">      The position to move to. </param>
    /// <param name="deltad">   The distance at which to stop moving. </param>
    ///
    /// <returns>   true if the is within deltad of pos and false if the unit had to
    ///             move </returns>
    ///-------------------------------------------------------------------------------------------------
    public bool moveTo(Vector3 pos, float deltad)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        
        if (agent == null)
        {
            throw new InvalidOperationException("moving a unit requiers that that unit has a navMeshAgent");
        }
        if (Vector3.Distance(transform.position, pos) <= deltad)
        {
            agent.ResetPath();
            return true;
        }
        else
        {
            //make sure that we dont randomly reassign the path
            //and cause the agent to recalculate all the time
            //still if something screws with our path we want to clobber
            //that change, if a command is executing it can assume that
            //it is the most important command
            agent.destination = pos;
            
            return false;
            
        }
    }
    public IEnumerator coMoveTo(Vector3 pos, float deltad)
    {
        while (!moveTo(pos, deltad))
        {
            yield return null;
        }
    }
    private void setMoving(bool val)
    {
        Animator anim = GetComponentInChildren<Animator>();
        if (anim != null && anim.GetBool("Moving") != val)
        {
            anim.SetBool("Moving", val);
        }
    }
    

    
    
    
}

