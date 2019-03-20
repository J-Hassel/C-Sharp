using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string roman = "MMXVII";
            Context context = new Context(roman);

            List<Expression> tree = new List<Expression>();
            tree.Add(new ThousandExpression());
            tree.Add(new HundredExpression());
            tree.Add(new TenExpression());
            tree.Add(new OneExpression());

            foreach(Expression exp in tree)
            {
                exp.Interpret(context);
            }

            Console.WriteLine($"{roman} = {context.Output}");
        }
    }

    class Context
    {
        private string _input;
        private int _output;

        public Context(string input)
        {
            _input = input;
        }

        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }

        public int Output
        {
            get { return _output; }
            set { _output = value; }
        }
    }

    abstract class Expression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.StartsWith(Nine()))
            {
                context.Output += (9 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if(context.Input.StartsWith(Four()))
            {
                context.Output += (4 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Five()))
            {
                context.Output += (5 * Multiplier());
                context.Input = context.Input.Substring(1);
            }

            while (context.Input.StartsWith(One()))
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(1);
            }
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }

    class ThousandExpression : Expression
    {
        public override string One() => "M";

        public override string Four() => " ";

        public override string Five() => " ";

        public override string Nine() => " ";

        public override int Multiplier() => 1000;
    }

    class HundredExpression : Expression
    {
        public override string One() => "C";

        public override string Four() => "CD";

        public override string Five() => "D";

        public override string Nine() => "CM";

        public override int Multiplier() => 100;
    }

    class TenExpression : Expression
    {
        public override string One() => "X";

        public override string Four() => "XL";

        public override string Five() => "L";

        public override string Nine() => "XC";

        public override int Multiplier() => 10;
    }

    class OneExpression : Expression
    {
        public override string One() => "I";

        public override string Four() => "IV";

        public override string Five() => "V";

        public override string Nine() => "IX";

        public override int Multiplier() => 1;
    }
}
