﻿namespace Calculator
{
    static class TokenStringRepresentation
    {
        public const string Division = "÷";
        public const string Addition = "+";
        public const string Subtraction = "-";
        public const string Multiplication = "×";
        public const string OpeningParenthesis = "(";
        public const string ClosingParenthesis = ")";
    }

    class Token
    {
        protected Token(TokenType tokenType, string stringRepresentation = "")
        {
            _tokenType = tokenType;
            _stringRepresentation = stringRepresentation;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Token)
                return false;
            return _tokenType == (obj as Token)._tokenType;
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return _stringRepresentation;
        }

        public virtual Token Clone()
        {
            return new Token(_tokenType, _stringRepresentation);
        }

        public virtual void RemoveLastCharacter()
        {
            _stringRepresentation = _stringRepresentation.Remove(_stringRepresentation.Length - 1);
        }

        public enum TokenType
        {
            Decimal,
            Operator,
            Undefined,
            Parenthesis
        }

        public int Length
        {
            get
            {
                return _stringRepresentation.Length;
            }
        }

        private readonly TokenType _tokenType;
        public string _stringRepresentation;

        /// Token constants
        public static readonly Token Decimal = new(TokenType.Decimal);
        public static readonly Token Operator = new(TokenType.Operator);
        public static readonly Token Undefined = new(TokenType.Undefined);
        public static readonly Token Parenthesis = new(TokenType.Parenthesis);
    }
}
