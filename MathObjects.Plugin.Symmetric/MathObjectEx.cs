using System;
using MathObjects.Framework;
using MathObjects.Core.Matrix.Permutation;

namespace MathObjects.Plugin.Symmetric
{
    public static class MathObjectEx
    {
        public static CycleList GetCycleList(this IMathObject obj)
        {
            var hasMatrix = obj as IHasMatrix;
            if (hasMatrix != null)
            {
                var perm = new PermutationMatix(hasMatrix.Matrix);
                return CycleList.Create(perm.Switches);
            }

            var hasOutput = obj as IHasOutput;
            if (hasOutput != null)
            {
                var output = hasOutput.Output;
                if (output is IMathObject)
                {
                    var hasMatrix2 = output as IHasMatrix;
                    if (hasMatrix2 != null)
                    {
                        var perm = new PermutationMatix(hasMatrix2.Matrix);
                        return CycleList.Create(perm.Switches);
                    }

                    return GetCycleList((IMathObject)output);
                }
            }

            throw new Exception();
        }
    }
}

