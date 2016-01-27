using System;
using System.IO;

namespace MathObjects.Framework.Parser
{
    public static class MathObjectStackEx
    {
        public static string Print(this MathObjectStack stack)
        {
            var writer = new StringWriter(); 

            stack.Print(writer);

            writer.Flush();

            return writer.ToString();
        }

        public static void Print(this MathObjectStack stack, TextWriter writer)
        {
            Print(0, stack.Top, writer);

            PrintChildren(0, stack.Top, writer);
        }

        public static void PrintChildren(int depth, IMathObject target, TextWriter writer)
        {
            var hasChildren = target as IHasChildren;

            if (hasChildren != null)
            {
                depth++;
                foreach (var child in hasChildren.Children)
                {
                    Print(depth, child, writer);

                    PrintChildren(depth, child, writer);
                }
            }
        }
        
        static void Print(int depth, IMathObject obj, TextWriter writer)
        {
            for (int i = 0; i < depth; i++)
            {
                writer.Write("     ");
            }

            for (;;)
            {
                var display = obj as IHasDisplayValue;
                if (display != null)
                {
                    writer.WriteLine(display.DisplayValue);
                    break;
                }

                var hasOutput = obj as IHasOutput;
                if (hasOutput != null)
                {
                    writer.WriteLine(hasOutput.Output.ToString());
                    break;
                }

                writer.WriteLine(obj.ToString());
                break;
            }
        }
    }
}

