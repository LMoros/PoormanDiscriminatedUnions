using System;

namespace TestPatternMatching
{
    public class DiscriminatedUnion<T1,T2,T3,T4> 
    {
        protected readonly T1 A;
        protected readonly T2 B;
        protected readonly T3 C;
        protected readonly T4 D;

        enum types
        {
            a,
            b,
            c,
            d,
        }

        private readonly types ContainedType;

        protected DiscriminatedUnion(T1 a)
        {
            ContainedType = types.a;
            A = a;
        }

        protected DiscriminatedUnion(T2 b)
        {
            ContainedType = types.b;
            B = b;
        }

        protected DiscriminatedUnion(T3 c)
        {
            ContainedType = types.c;
            C = c;
        }

        protected DiscriminatedUnion(T4 d)
        {
            ContainedType = types.d;
            D = d;
        }

        public TR Match<TR>(
            Func<T1, TR> funA,
            Func<T2, TR> funB,
            Func<T3, TR> funC,
            Func<T4, TR> funD)
        {
            switch (ContainedType)
            {
                case types.a:
                    return funA(A);
                case types.b:
                    return funB(B);
                case types.c:
                    return funC(C);
                case types.d:
                    return funD(D);
                default:
                    throw new Exception("match not found");
            };
        }
    }

    public class MyUnion : DiscriminatedUnion<int, string, DateTime, bool>
    {
        protected MyUnion(int a) : base(a)
        {}

        protected MyUnion(string b) : base(b)
        { }

        protected MyUnion(DateTime c) : base(c)
        { }

        protected MyUnion(bool d) : base(d)
        { }

        public static implicit operator int(MyUnion union)
        {
            return union.A;
        }

        public static implicit operator MyUnion(int a)
        {
            return new MyUnion(a);
        }

        public static implicit operator string(MyUnion union)
        {
            return union.B;
        }

        public static implicit operator MyUnion(string b)
        {
            return new MyUnion(b);
        }

        public static implicit operator DateTime(MyUnion union)
        {
            return union.C;
        }

        public static implicit operator MyUnion(DateTime c)
        {
            return new MyUnion(c);
        }

        public static implicit operator bool(MyUnion union)
        {
            return union.D;
        }

        public static implicit operator MyUnion(bool d)
        {
            return new MyUnion(d);
        }
    }
}
