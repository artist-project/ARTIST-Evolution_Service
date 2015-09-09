grammar GML;

ruleGoalModel
	: ruleImportNamespace* 'goalmodel' ruleQualifiedName '{' 'workloads' '[' ( ruleWorkload ( ',' ruleWorkload )* )? ']' 'applied-properties' '[' ( ruleAppliedProperty ( ',' ruleAppliedProperty )* )? ']' 'goals' '[' ( ruleGoal ( ',' ruleGoal )* )? ']' '}'
	;

ruleWorkload
	: RULE_ID '{' 'activity' ruleQualifiedName ',' 'pattern' RULE_STRING '}'
	;


ruleAppliedProperty
	: ruleAppliedQualitativeProperty
	| ruleAppliedQuantitativeProperty
	;

ruleAppliedQualitativeProperty
	: 'qualitative' RULE_ID '{' 'property' ruleQualifiedName ( ',' 'context' '[' ( ruleQualifiedName ( ',' ruleQualifiedName )* )? ']' )? '}'
	;

ruleAppliedQuantitativeProperty
	: 'quantitative' RULE_ID '{' 'property' ruleQualifiedName ( ',' 'function' ( 'min' | 'max' | 'avg' | 'sum' ) )? ( ',' 'context' '[' ( ruleQualifiedName ( ',' ruleQualifiedName )* )? ']' )? ( ',' 'workload' ruleQualifiedName )? '}'
	;

ruleGoal 
	: ruleSoftGoal
	| ruleHardGoal
	| ruleCompositeGoal
	;

ruleSoftGoal
	: 'softgoal' RULE_ID '{' 'kind' ruleGoalKind ',' 'priority' RULE_INT ',' 'property' '$' ruleQualifiedName ',' 'threshold' ruleImpact ( ',' 'impacts' '[' ruleSoftGoalImpact ( ',' ruleSoftGoalImpact )* ']' )? '}'
	;

ruleSoftGoalImpact
	: ruleQualifiedName ruleImpact
	;

ruleHardGoal
	: 'hardgoal' RULE_ID '{' 'kind' ruleGoalKind ',' 'priority' RULE_INT ',' 'condition' ruleExpression ( ',' 'successRate' RULE_POSITIVE_SMALL_DECIMAL )? '}'
	;

ruleCompositeGoal
	: 'composite' RULE_ID '{' 'kind' ruleGoalKind ',' 'priority' RULE_INT ',' 'condition' ruleGoalExpression '}'
	;

ruleGoalExpression
	: ruleGoalImplication
	;

ruleGoalImplication
	: ruleGoalDisjunction ( ruleImplicationOperator ruleGoalDisjunction )*
	;

ruleGoalDisjunction
	: ruleGoalConjunction ( ( ruleOrOperator | ruleXOrOperator ) ruleGoalConjunction )*
	;

ruleGoalConjunction
	: ruleGoalComparison ( ruleAndOperator ruleGoalComparison )*
	;

ruleGoalComparison
	: ruleGoalBooleanUnit ( ( '==' | ruleNotEqualsOperator ) ruleGoalBooleanUnit )*
	;

ruleGoalBooleanUnit
	: ruleGoalNegation
	| ruleGoalBooleanLiteral
	| ruleGoalReference
	| ruleParenthesizedGoalExpression
	;

ruleGoalNegation
	: ruleNotOperator ruleGoalBooleanUnit
	;

ruleGoalBooleanLiteral
	: RULE_EBOOLEAN
	;

ruleGoalReference
	: '$' ruleQualifiedName
	;

ruleParenthesizedGoalExpression
	: '(' ruleGoalExpression ')'
	;

ruleNumberExpression
	: ruleNumberLiteral
	| ruleNumberFunction
	| ruleAppliedQuantitativePropertyExpression
	;

ruleAppliedQuantitativePropertyExpression
	: '$' ruleQualifiedName
	;

ruleExpression
	: ruleImplication
	;

ruleImplication
	: ruleDisjunction ( ruleImplicationOperator ruleDisjunction )*
	;

ruleDisjunction
	: ruleConjunction ( ( ruleOrOperator | ruleXOrOperator ) ruleConjunction )*
	;

ruleConjunction
    : ruleComparison ( ruleAndOperator ruleComparison )*
	;

ruleComparison
    : ruleBooleanUnit ( ( '==' | ruleNotEqualsOperator ) ruleBooleanUnit )*
	;

ruleBooleanUnit
	: ruleNegation
    | ruleRelationalExpression
    | ruleBooleanLiteral
	;

ruleNegation
	: ruleNotOperator ruleBooleanUnit
	;

ruleRelationalExpression
	: ruleComparableExpression ( ( '>' | '>=' | '<=' | '<' ) ruleComparableExpression )*
	;

ruleComparableExpression
	: ruleArithmeticExpression
	| ruleInstanceSpecificationExpression
    | ruleObjectSpecificationExpression
	| ruleNullLiteral
	| ruleStringLiteral
	| '*'
	| ruleParenthesizedExpression
	;

ruleArithmeticExpression
    : ruleAdditiveExpression
	;

ruleAdditiveExpression
    : ruleMultiplicativeExpression ( ( '-' | '+' ) ruleMultiplicativeExpression )*
	;

ruleMultiplicativeExpression
    : ruleNumberExpression ( ( '*' | '/' | '%' ) ruleNumberExpression )*
	;

ruleNumberFunction
	: ruleMaximumFunction
	| ruleMinimumFunction
	| ruleAverageFunction
	| ruleSumFunction
	| ruleExponentialFunction
	| ruleAbsoluteFunction
	| ruleNaturalLogarithmFunction
	| ruleCommonLogarithmFunction
	;

ruleMaximumFunction
	: 'max' '(' ruleNumberExpression ( ',' ruleNumberExpression )* ')'
	;

ruleMinimumFunction
	: 'min' '(' ruleNumberExpression ( ',' ruleNumberExpression )* ')'
	;

ruleAverageFunction
    : 'avg' '(' ruleNumberExpression ( ',' ruleNumberExpression )* ')'
	;

ruleSumFunction
    : 'sum' '(' ruleNumberExpression ( ',' ruleNumberExpression )* ')'
	;

ruleExponentialFunction
    : 'exp' '(' ruleNumberExpression ',' ruleNumberExpression ')'
	;

ruleAbsoluteFunction
    : 'abs' '(' ruleNumberExpression ')'
	;

ruleNaturalLogarithmFunction
    : 'ln' '(' ruleNumberExpression ')'
	;

ruleCommonLogarithmFunction
    : 'log' '(' ruleNumberExpression ')'
	;

ruleParenthesizedExpression
	: '(' ruleExpression ')'
	;

ruleValueSpecification
	: ruleLiteralValueExpression
	| ruleInstanceSpecificationExpression
	| ruleObjectSpecificationExpression
	;

ruleObjectSpecificationExpression
    : ruleQualifiedName ( ruleCollection | ruleTuple )
	;

ruleCollection
    : '[' ( ruleValueSpecification ( ',' ruleValueSpecification )* )? ']'
	;

ruleTuple
    : '{' ( rulePropertyValuePair ( ',' rulePropertyValuePair )* )? '}'
	;

rulePropertyValuePair
    : ruleQualifiedName '=' ruleValueSpecification
	;

ruleInstanceSpecificationExpression
    : ruleQualifiedName
	;

ruleLiteralValueExpression
    : ruleNumberLiteral
	| ruleBooleanLiteral
	| ruleNullLiteral
	| ruleStringLiteral
	| '*'
	;

ruleBooleanLiteral
	: RULE_EBOOLEAN
	;

ruleNumberLiteral
	: ruleNumber
	;

ruleNullLiteral
	: 'null'
	;

ruleStringLiteral
	: RULE_STRING
	;

ruleOrOperator
	: 'or'
	| '||'
	;

ruleXOrOperator
	: 'xor'
	| '^'
	;

ruleAndOperator
    : 'and'
	| '&&'
	;

ruleImplicationOperator
    : '=>'
    | '->'
	;

ruleNotEqualsOperator
    : '!='
	| '<>'
	;

ruleNotOperator
    : '!'
	| 'not'
	;

ruleQualifiedName
	: RULE_ID ( '.' RULE_ID )*
	;

ruleQualifiedNameWithWildcard
	: ruleQualifiedName '.*'?
	;

ruleImportNamespace
    : 'import' ruleQualifiedNameWithWildcard
	;

ruleNumber
	: RULE_INT
	| RULE_POSITIVE_SMALL_DECIMAL
	| RULE_SMALL_DECIMAL
	| RULE_EBIGDECIMAL
	;

ruleImpact
    : RULE_POSITIVE_SMALL_DECIMAL
	| RULE_SMALL_DECIMAL
	;

ruleGoalKind
    : 'required'
	| 'offered'
	| 'contract'
	;

RULE_EBOOLEAN
	: 'true'
	| 'false'
	;

RULE_INT
	: [0-9]+
	;

RULE_POSITIVE_SMALL_DECIMAL
	: '1' ( '.' '0'+ )?
	| '0' ( '.' [0-9]+ )?
	| '.' [0-9]+
	;

RULE_SMALL_DECIMAL
	: ( '+' | '-' )? RULE_POSITIVE_SMALL_DECIMAL
	;

RULE_EBIGDECIMAL
	: ( '+' | '-' )? ( RULE_INT | '.' RULE_INT | RULE_INT '.' RULE_INT )
	;

RULE_ID
	: '^'? ( [a-z] | [A-Z] | '_' | '+' | '-' | '%' | '*' | '/' | '#' | '>' | '<' | '=') ( [a-z] | [A-Z] | '_' | [0-9] | '+' | '-' | '%' | '*' | '/' | '#' | '>' | '<' | '=')*
	;

RULE_STRING
	:   '"' DoubleStringCharacters? '"'
	|   '\'' SingleStringCharacters? '\''
	;

fragment
DoubleStringCharacters
	:   DoubleStringCharacter+
	;

fragment
DoubleStringCharacter
	:   ~["\\]
	|   '\\' [btnfr"'\\]
	;

fragment
SingleStringCharacters
	:   SingleStringCharacter+
	;

fragment
SingleStringCharacter
	:   ~['\\]
	|   '\\' [btnfr"'\\]
	;

WS
	:	[ \t\r\n\u000C]+ -> skip
	;