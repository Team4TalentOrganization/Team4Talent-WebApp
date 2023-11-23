�
�C:\Users\Lucah\Documents\School\2023-2024\IT-Project\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Domain\Exceptions\BusinessException.cs
	namespace 	

 
. 
Domain 
. 

Exceptions )
{		 
[ 
Serializable 
] 
public 

class 
BusinessException "
:# $
	Exception% .
{ 
public 
BusinessException  
(  !
)! "
{ 	
} 	
public 
BusinessException  
(  !
string! '
message( /
)/ 0
: 
base 
( 
message 
) 
{ 	
} 	
public 
BusinessException  
(  !
string! '
message( /
,/ 0
	Exception1 :
inner; @
)@ A
: 
base 
( 
message 
, 
inner !
)! "
{ 	
} 	
	protected 
BusinessException #
(# $
SerializationInfo$ 5
info6 :
,: ;
StreamingContext< L
contextM T
)T U
:   
base   
(   
info   
,   
context    
)    !
{!! 	
}"" 	
}## 
}$$ �
tC:\Users\Lucah\Documents\School\2023-2024\IT-Project\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Domain\Option.cs
	namespace 	

 
. 
Domain 
{ 
public 

class 
Option 
{ 
private 
string 
_content 
=  !
string" (
.( )
Empty) .
;. /
private 
int 
_optionRelation #
;# $
private		 
int		 
_questionId		 
;		  
public 
int 
OptionId 
{ 
get !
;! "
set# &
;& '
}( )
public
int
OptionRelation
{ 	
get 
=> 
_optionRelation "
;" #
set 
{ 
if 
( 
value 
<= 
$num 
) 
{ 
throw 
new 
BusinessException /
(/ 0
$str0 X
)X Y
;Y Z
} 
_optionRelation 
=  !
value" '
;' (
} 
} 	
public 
int 

QuestionId 
{ 	
get 
=> 
_questionId 
; 
set 
{ 
if   
(   
value   
<=   
$num   
)   
{!! 
throw"" 
new"" 
BusinessException"" /
(""/ 0
$str""0 T
)""T U
;""U V
}## 
_questionId%% 
=%% 
value%% #
;%%# $
}&& 
}'' 	
public)) 
string)) 
Content)) 
{** 	
get++ 
=>++ 
_content++ 
;++ 
set,, 
{-- 
if.. 
(.. 
string.. 
... 

(..( )
value..) .
)... /
)../ 0
{// 
throw00 
new00 
BusinessException00 /
(00/ 0
$str000 R
)00R S
;00S T
}11 
_content33 
=33 
value33  
;33  !
}44 
}55 	
public77 
bool77 
	IsChecked77 
{77 
get77  #
;77# $
set77% (
;77( )
}77* +
=77, -
false77. 3
;773 4
}88 
}99 �
vC:\Users\Lucah\Documents\School\2023-2024\IT-Project\Team4Talent-WebApp\StudyGuidance\StudyGuidance.Domain\Question.cs
	namespace 	

 
. 
Domain 
{ 
public 

class 
Question 
{ 
private 
string 
_phrase 
=  
string! '
.' (
Empty( -
;- .
private 
List 
< 
Option 
> 
_options %
=& '
new( +
List, 0
<0 1
Option1 7
>7 8
(8 9
)9 :
;: ;
public

 
int

 

QuestionId

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 
string 
Phrase 
{
get 
=> 
_phrase 
; 
set 
{ 
if 
( 
string 
. 

(( )
value) .
). /
)/ 0
{ 
throw 
new 
BusinessException /
(/ 0
$str0 P
)P Q
;Q R
} 
_phrase 
= 
value 
;  
} 
} 	
public 
List 
< 
Option 
> 
Options #
{ 	
get 
=> 
_options 
; 
set 
{ 
if 
( 
value 
== 
null !
||" $
!% &
value& +
.+ ,
Any, /
(/ 0
)0 1
)1 2
{   
throw!! 
new!! 
BusinessException!! /
(!!/ 0
$str!!0 W
)!!W X
;!!X Y
}"" 
_options$$ 
=$$ 
value$$  
;$$  !
}%% 
}&& 	
}'' 
}(( 