using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStack : AbstractAnimator
{
    [SerializeField] private AbstractAnimator[] abstractAnimatorsStack;
    [SerializeField] protected AnimatorType animatorType;

    private AbstractAnimator exitAnimation;

    public override void Init(AbstractItem item)
    {
        base.Init(item);
        for (int i = 0; i < abstractAnimatorsStack.Length; i++)
        {
            abstractAnimatorsStack[i].Init(Item);
        }
    }

    public override void Animate()
    {
        switch (animatorType)
        {
            case AnimatorType.allInOne: AllItOneAnimation(); break;
            case AnimatorType.sequence: SequenceAnimation(); break;
        }
    }

    private void AllItOneAnimation()
    {
        for (int i = 0; i < abstractAnimatorsStack.Length; i++)
        {
            abstractAnimatorsStack[i].Animate();
            if (i == abstractAnimatorsStack.Length - 1)
            {
                exitAnimation = abstractAnimatorsStack[i];
                abstractAnimatorsStack[i].OnAnimationExit += ExitStack;
            }
        }
    }
    private void SequenceAnimation()
    {
        for (int i = 0; i < abstractAnimatorsStack.Length; i++)
        {
            if (i == abstractAnimatorsStack.Length - 1)
            {
                abstractAnimatorsStack[i].OnAnimationExit += ExitSequence;
                exitAnimation = abstractAnimatorsStack[i];
            }
            else
            {
                abstractAnimatorsStack[i].OnAnimationExit += abstractAnimatorsStack[i + 1].Animate;
            }
        }
        abstractAnimatorsStack[0].Animate();
    }
    public void ExitStack()
    {
        exitAnimation.OnAnimationExit -= ExitStack;
        base.Exit();
    }

    public void ExitSequence()
    {
        for (int i = 0; i < abstractAnimatorsStack.Length; i++)
        {
            if (i == abstractAnimatorsStack.Length - 1)
            {
                abstractAnimatorsStack[i].OnAnimationExit -= ExitSequence;
            }
            else
            {
                abstractAnimatorsStack[i].OnAnimationExit -= abstractAnimatorsStack[i + 1].Animate;
            }
        }
        base.Exit();
    }
}

public enum AnimatorType
{
    sequence, allInOne
}
