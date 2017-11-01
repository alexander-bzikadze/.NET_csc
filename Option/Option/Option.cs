using System;
using System.Collections.Generic;
using NUnit.Framework;
using Option.Exceptions;

namespace Option
{
    public class Option<T> : IEquatable<Option<T>>
    {
        private Option(T val, bool isSome = true)
        {
            _val = val;
            _isSome = isSome;
        }

        private Option() :
            this(default(T), false)
        {}

        static Option()
        {
            _none = new Option<T>();
        }

        private readonly T _val;
        private readonly bool _isSome;
        private static readonly Option<T> _none;

        public static Option<T> None() => _none;

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

        public Option<TResult> Map<TResult>(Func<T, TResult> f) => _isSome ? Option<TResult>.Some(f(_val)) : Option<TResult>.None();

        public static Option<T> Flatten(Option<Option<T>> option)
            => option.IsSome() && option.Value().IsSome() ? Some(option.Value().Value()) : None();

        public bool Equals(Option<T> other) => 
            !_isSome && !other._isSome || 
            _isSome && other._isSome && EqualityComparer<T>.Default.Equals(_val, other._val);
        
        public override bool Equals(object obj) => obj is Option<T> && Equals((Option<T>)obj);

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(_val) * 397) ^ _isSome.GetHashCode();
            }
        }
        
        public static bool operator ==(Option<T> left, Option<T> right) => left.Equals(right);
        public static bool operator !=(Option<T> left, Option<T> right) => !left.Equals(right);
    }
}