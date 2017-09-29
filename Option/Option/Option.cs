using System;
using Option.Exceptions;

namespace Option
{
    public class Option<T>
    {
        private Option(T val, bool isSome = true)
        {
            _val = val;
            _isSome = isSome;
        }

        private Option() :
            this(default(T), false)
        {}

        private readonly T _val;
        private readonly bool _isSome;

        public static Option<T> None() => new Option<T>();

        public static Option<T> Some(T val) => new Option<T>(val);

        public bool IsSome() => _isSome;

        public bool IsNone() => !_isSome;

        public T Value()
        {
            if (IsNone())
            {
                throw new UnBoxNoneOptionException();
            }
            return _val;
        }

        public Option<U> Map<U>(Func<T, U> f) => _isSome ? Option<U>.Some(f(_val)) : Option<U>.None();

        public static Option<T> Flatten(Option<Option<T>> option)
            => option.IsSome() && option.Value().IsSome() ? Some(option.Value().Value()) : None();
    }
}