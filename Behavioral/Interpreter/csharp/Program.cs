using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            Context context = new Context
            {
                formula = "CCI"
            };

            Manager manager = new Manager();
            manager.RunExpression(context);

            Console.WriteLine($"Material Codes: {context.formula}, Cost: {context.cost}");

            Console.Read();
        }
    }

    public interface IExpression
    {
        void Interpret(Context context);
    }

    public class Context
    {
        public string formula { get; set; }
        public decimal cost { get; set; }
    }

    public class CementExpression : IExpression
    {
        public void Interpret(Context context)
        {
            if (context.formula.Contains("C"))
                context.cost += 2000;
        }
    }

    public class IronExpression : IExpression
    {
        public void Interpret(Context context)
        {
            if (context.formula.Contains("I"))
                context.cost += 3000;
        }
    }

    public class Manager
    {
        public List<IExpression> ExpressionTree(string formula)
        {
            List<IExpression> expressions = new List<IExpression>();

            foreach (char item in formula)
            {
                switch (item)
                {
                    case 'C':
                        expressions.Add(new CementExpression());
                        break;
                    case 'I':
                        expressions.Add(new IronExpression());
                        break;
                    default:
                        throw new Exception("Unexpected material");
                }
            }

            return expressions;
        }

        public void RunExpression(Context context)
        {
            foreach (IExpression expression in ExpressionTree(context.formula))
            {
                expression.Interpret(context);
            }
        }
    }
}