using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {

	public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator PlayerTurn()
    {
        yield break;
    }
    public virtual IEnumerator EnemyTurn()
    {
        yield break;
    }
    public virtual IEnumerator Decision()
    {
        yield break;
    }
    public virtual IEnumerator Victory()
    {
        yield break;
    }
    public virtual IEnumerator Defeat()
    {
        yield break;
    }
    public virtual IEnumerator Draw()
    {
        yield break;
    }



}
