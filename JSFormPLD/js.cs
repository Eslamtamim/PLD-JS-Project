
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF = 0, // (EOF)
        SYMBOL_ERROR = 1, // (Error)
        SYMBOL_WHITESPACE = 2, // Whitespace
        SYMBOL_MINUS = 3, // '-'
        SYMBOL_EXCLAMEQ = 4, // '!='
        SYMBOL_LPAREN = 5, // '('
        SYMBOL_RPAREN = 6, // ')'
        SYMBOL_TIMES = 7, // '*'
        SYMBOL_DIV = 8, // '/'
        SYMBOL_SEMI = 9, // ';'
        SYMBOL_PLUS = 10, // '+'
        SYMBOL_LT = 11, // '<'
        SYMBOL_LTEQ = 12, // '<='
        SYMBOL_EQ = 13, // '='
        SYMBOL_EQEQ = 14, // '=='
        SYMBOL_EQEQEQ = 15, // '==='
        SYMBOL_GT = 16, // '>'
        SYMBOL_GTEQ = 17, // '>='
        SYMBOL_CONST = 18, // const
        SYMBOL_DO = 19, // do
        SYMBOL_FOR = 20, // for
        SYMBOL_IDENTIFIER = 21, // Identifier
        SYMBOL_LET = 22, // let
        SYMBOL_STRINGLITERAL = 23, // StringLiteral
        SYMBOL_VAR = 24, // var
        SYMBOL_WHILE = 25, // while
        SYMBOL_ADDEXP = 26, // <Add Exp>
        SYMBOL_DOWHILELOOP = 27, // <DoWhileLoop>
        SYMBOL_EXPRESSION = 28, // <Expression>
        SYMBOL_FORINIT = 29, // <ForInit>
        SYMBOL_FORLOOP = 30, // <ForLoop>
        SYMBOL_MULTEXP = 31, // <Mult Exp>
        SYMBOL_NEGATEEXP = 32, // <Negate Exp>
        SYMBOL_PROGRAM = 33, // <Program>
        SYMBOL_STATEMENT = 34, // <Statement>
        SYMBOL_STATEMENTLIST = 35, // <StatementList>
        SYMBOL_VALUE = 36, // <Value>
        SYMBOL_VARIABLEDECLARATION = 37, // <VariableDeclaration>
        SYMBOL_WHILELOOP = 38  // <WhileLoop>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM = 0, // <Program> ::= <StatementList>
        RULE_STATEMENTLIST = 1, // <StatementList> ::= <StatementList> <Statement>
        RULE_STATEMENTLIST2 = 2, // <StatementList> ::= <Statement>
        RULE_VARIABLEDECLARATION_VAR_IDENTIFIER_EQ_SEMI = 3, // <VariableDeclaration> ::= var Identifier '=' <Expression> ';'
        RULE_VARIABLEDECLARATION_LET_IDENTIFIER_EQ_SEMI = 4, // <VariableDeclaration> ::= let Identifier '=' <Expression> ';'
        RULE_VARIABLEDECLARATION_CONST_IDENTIFIER_EQ_SEMI = 5, // <VariableDeclaration> ::= const Identifier '=' <Expression> ';'
        RULE_STATEMENT = 6, // <Statement> ::= <Expression>
        RULE_STATEMENT2 = 7, // <Statement> ::= <ForLoop>
        RULE_STATEMENT3 = 8, // <Statement> ::= <WhileLoop>
        RULE_STATEMENT4 = 9, // <Statement> ::= <DoWhileLoop>
        RULE_STATEMENT5 = 10, // <Statement> ::= <VariableDeclaration>
        RULE_FORLOOP_FOR_LPAREN_SEMI_SEMI_RPAREN = 11, // <ForLoop> ::= for '(' <ForInit> ';' <Expression> ';' <Expression> ')' <Expression>
        RULE_FORINIT = 12, // <ForInit> ::= <VariableDeclaration>
        RULE_FORINIT2 = 13, // <ForInit> ::= <Expression>
        RULE_WHILELOOP_WHILE_LPAREN_RPAREN = 14, // <WhileLoop> ::= while '(' <Expression> ')' <Expression>
        RULE_DOWHILELOOP_DO_WHILE_LPAREN_RPAREN_SEMI = 15, // <DoWhileLoop> ::= do <Expression> while '(' <Expression> ')' ';'
        RULE_EXPRESSION_GT = 16, // <Expression> ::= <Expression> '>' <Add Exp>
        RULE_EXPRESSION_LT = 17, // <Expression> ::= <Expression> '<' <Add Exp>
        RULE_EXPRESSION_LTEQ = 18, // <Expression> ::= <Expression> '<=' <Add Exp>
        RULE_EXPRESSION_GTEQ = 19, // <Expression> ::= <Expression> '>=' <Add Exp>
        RULE_EXPRESSION_EQEQ = 20, // <Expression> ::= <Expression> '==' <Add Exp>
        RULE_EXPRESSION_EQEQEQ = 21, // <Expression> ::= <Expression> '===' <Add Exp>
        RULE_EXPRESSION_EXCLAMEQ = 22, // <Expression> ::= <Expression> '!=' <Add Exp>
        RULE_EXPRESSION = 23, // <Expression> ::= <Add Exp>
        RULE_ADDEXP_PLUS = 24, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
        RULE_ADDEXP_MINUS = 25, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
        RULE_ADDEXP = 26, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP_TIMES = 27, // <Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
        RULE_MULTEXP_DIV = 28, // <Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
        RULE_MULTEXP = 29, // <Mult Exp> ::= <Negate Exp>
        RULE_NEGATEEXP_MINUS = 30, // <Negate Exp> ::= '-' <Value>
        RULE_NEGATEEXP = 31, // <Negate Exp> ::= <Value>
        RULE_VALUE_IDENTIFIER = 32, // <Value> ::= Identifier
        RULE_VALUE_LPAREN_RPAREN = 33  // <Value> ::= '(' <Expression> ')'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox listBox1;
        ListBox listBox2;

        public MyParser(string filename, ListBox listBox1, ListBox listBox2)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            Init(stream);
            stream.Close();
            this.listBox1 = listBox1;
            this.listBox2 = listBox2;
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            var token = args.Token.ToString() + "\t \t" + args.Token.Symbol.Id;
            listBox2.Items.Clear();
            listBox2.Items.Add(token);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF:
                    //(EOF)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ERROR:
                    //(Error)
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE:
                    //Whitespace
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MINUS:
                    //'-'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ:
                    //'!='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LPAREN:
                    //'('
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_RPAREN:
                    //')'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_TIMES:
                    //'*'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DIV:
                    //'/'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_SEMI:
                    //';'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PLUS:
                    //'+'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LT:
                    //'<'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LTEQ:
                    //'<='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EQ:
                    //'='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EQEQ:
                    //'=='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EQEQEQ:
                    //'==='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_GT:
                    //'>'
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_GTEQ:
                    //'>='
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_CONST:
                    //const
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DO:
                    //do
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FOR:
                    //for
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER:
                    //Identifier
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_LET:
                    //let
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL:
                    //StringLiteral
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_VAR:
                    //var
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHILE:
                    //while
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP:
                    //<Add Exp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_DOWHILELOOP:
                    //<DoWhileLoop>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION:
                    //<Expression>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FORINIT:
                    //<ForInit>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_FORLOOP:
                    //<ForLoop>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP:
                    //<Mult Exp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP:
                    //<Negate Exp>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM:
                    //<Program>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT:
                    //<Statement>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST:
                    //<StatementList>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_VALUE:
                    //<Value>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATION:
                    //<VariableDeclaration>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

                case (int)SymbolConstants.SYMBOL_WHILELOOP:
                    //<WhileLoop>
                    //todo: Create a new object that corresponds to the symbol
                    return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM:
                    //<Program> ::= <StatementList>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENTLIST:
                    //<StatementList> ::= <StatementList> <Statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENTLIST2:
                    //<StatementList> ::= <Statement>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_VAR_IDENTIFIER_EQ_SEMI:
                    //<VariableDeclaration> ::= var Identifier '=' <Expression> ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_LET_IDENTIFIER_EQ_SEMI:
                    //<VariableDeclaration> ::= let Identifier '=' <Expression> ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_CONST_IDENTIFIER_EQ_SEMI:
                    //<VariableDeclaration> ::= const Identifier '=' <Expression> ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT:
                    //<Statement> ::= <Expression>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT2:
                    //<Statement> ::= <ForLoop>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT3:
                    //<Statement> ::= <WhileLoop>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT4:
                    //<Statement> ::= <DoWhileLoop>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_STATEMENT5:
                    //<Statement> ::= <VariableDeclaration>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FORLOOP_FOR_LPAREN_SEMI_SEMI_RPAREN:
                    //<ForLoop> ::= for '(' <ForInit> ';' <Expression> ';' <Expression> ')' <Expression>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FORINIT:
                    //<ForInit> ::= <VariableDeclaration>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_FORINIT2:
                    //<ForInit> ::= <Expression>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_WHILELOOP_WHILE_LPAREN_RPAREN:
                    //<WhileLoop> ::= while '(' <Expression> ')' <Expression>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_DOWHILELOOP_DO_WHILE_LPAREN_RPAREN_SEMI:
                    //<DoWhileLoop> ::= do <Expression> while '(' <Expression> ')' ';'
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT:
                    //<Expression> ::= <Expression> '>' <Add Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT:
                    //<Expression> ::= <Expression> '<' <Add Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTEQ:
                    //<Expression> ::= <Expression> '<=' <Add Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTEQ:
                    //<Expression> ::= <Expression> '>=' <Add Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQEQ:
                    //<Expression> ::= <Expression> '==' <Add Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQEQEQ:
                    //<Expression> ::= <Expression> '===' <Add Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION_EXCLAMEQ:
                    //<Expression> ::= <Expression> '!=' <Add Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_EXPRESSION:
                    //<Expression> ::= <Add Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS:
                    //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS:
                    //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_ADDEXP:
                    //<Add Exp> ::= <Mult Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES:
                    //<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV:
                    //<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_MULTEXP:
                    //<Mult Exp> ::= <Negate Exp>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS:
                    //<Negate Exp> ::= '-' <Value>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_NEGATEEXP:
                    //<Negate Exp> ::= <Value>
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER:
                    //<Value> ::= Identifier
                    //todo: Create a new object using the stored tokens.
                    return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN:
                    //<Value> ::= '(' <Expression> ')'
                    //todo: Create a new object using the stored tokens.
                    return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "'";
            //todo: Report message to UI?

        }

        public void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "'";
            listBox1.Items.Add(message);
            string message2 = "Expected token: '" + args.ExpectedTokens.ToString() + "'";
            listBox1.Items.Add(message2);
        }

    }
}
