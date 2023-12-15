Á
hC:\Users\Gebruiker\itNieuwProj\Team4Talent-WebApp\StudyGuidance\StudyGuidance.AppLogic\IJobRepository.cs
	namespace 	
StudyGuidance
 
. 
AppLogic  
{ 
public 

	interface 
IJobRepository #
{ 
Task 
< 
IReadOnlyList 
< 
Job 
> 
>  
GetJobsAsync! -
(- .
). /
;/ 0
Task 
< 
IReadOnlyList 
< 
Job 
> 
>   
GetJobsByFilterAsync! 5
(5 6
List6 :
<: ;
int; >
>> ?
subdomainIds@ L
,L M
boolN R

workInTeamS ]
,] ^
bool_ c

workOnSited n
)n o
;o p
Task		 
<		 
Job		 
>		 
GetJobByIdAsync		 !
(		! "
int		" %
id		& (
)		( )
;		) *
}

 
} Ù
vC:\Users\Gebruiker\itNieuwProj\Team4Talent-WebApp\StudyGuidance\StudyGuidance.AppLogic\IQuestionModificationService.cs
	namespace 	
StudyGuidance
 
. 
AppLogic  
{		 
public

 

	interface

 (
IQuestionModificationService

 1
{ 
IReadOnlyList 
< 
Question 
> 
ModifyQuestions  /
(/ 0
IReadOnlyList0 =
<= >
Question> F
>F G
	questionsH Q
)Q R
;R S
} 
} Õ
iC:\Users\Gebruiker\itNieuwProj\Team4Talent-WebApp\StudyGuidance\StudyGuidance.AppLogic\IQuizRepository.cs
	namespace 	
StudyGuidance
 
. 
AppLogic  
{ 
public 

	interface 
IQuizRepository $
{ 
Task 
< 
IReadOnlyList 
< 
Question #
># $
>$ %
GetQuestionsAsync& 7
(7 8
)8 9
;9 :
Task 
< 
IReadOnlyList 
< 
Question #
># $
>$ %)
GetStandardQuizQuestionsAsync& C
(C D
)D E
;E F
Task		 
<		 
IReadOnlyList		 
<		 
Question		 #
>		# $
>		$ %'
GetTinderQuizQuestionsAsync		& A
(		A B
)		B C
;		C D
Task

 
<

 
IReadOnlyList

 
<

 
Question

 #
>

# $
>

$ %#
GetDomainQuestionsAsync

& =
(

= >
)

> ?
;

? @
Task 
< 
IReadOnlyList 
< 
Option !
>! "
>" #
GetDomainsAsync$ 3
(3 4
)4 5
;5 6
Task 
< 
IReadOnlyList 
< 
Question #
># $
>$ %&
GetSelectedSubDomainsAsync& @
(@ A
ListA E
<E F
intF I
>I J
domainIdK S
)S T
;T U
Task 
< 
IReadOnlyList 
< 
Option !
>! "
>" #/
#GetSelectedSubDomainsForFilterAsync$ G
(G H
)H I
;I J
} 
} õ%
uC:\Users\Gebruiker\itNieuwProj\Team4Talent-WebApp\StudyGuidance\StudyGuidance.AppLogic\QuestionModificationService.cs
	namespace 	
StudyGuidance
 
. 
AppLogic  
{ 
public 

class '
QuestionModificationService ,
:- .(
IQuestionModificationService/ K
{		 
public

 
IReadOnlyList

 
<

 
Question

 %
>

% &
ModifyQuestions

' 6
(

6 7
IReadOnlyList

7 D
<

D E
Question

E M
>

M N
	questions

O X
)

X Y
{ 	
List 
< 
Question 
> 
modifiedQuestions ,
=- .
new/ 2
List3 7
<7 8
Question8 @
>@ A
(A B
)B C
;C D
foreach 
( 
Question 
question &
in' )
	questions* 3
)3 4
{ 
if 
( 
question 
. 
Options $
.$ %
Count% *
<+ ,
$num- .
). /
{ 
int 
emptyOptionsToAdd )
=* +
$num, -
-. /
question0 8
.8 9
Options9 @
.@ A
CountA F
;F G
for 
( 
int 
i 
=  
$num! "
;" #
i$ %
<& '
emptyOptionsToAdd( 9
;9 :
i; <
++< >
)> ?
{ 
question  
.  !
Options! (
.( )
Add) ,
(, -
new- 0
Option1 7
(7 8
)8 9
)9 :
;: ;
} 
} 
else 
if 
( 
question !
.! "
Options" )
.) *
Count* /
>0 1
$num2 3
)3 4
{ 
var 
remainingOptions (
=) *
question+ 3
.3 4
Options4 ;
.; <
Skip< @
(@ A
$numA B
)B C
.C D
ToListD J
(J K
)K L
;L M
while 
( 
remainingOptions +
.+ ,
Count, 1
>2 3
$num4 5
)5 6
{ 
var 
newQuestion '
=( )
new* -
Question. 6
{   
Options!! #
=!!$ %
remainingOptions!!& 6
.!!6 7
Take!!7 ;
(!!; <
$num!!< =
)!!= >
.!!> ?
ToList!!? E
(!!E F
)!!F G
,!!G H

QuestionId"" &
=""' (
question"") 1
.""1 2

QuestionId""2 <
,""< =
Phrase## "
=### $
question##% -
.##- .
Phrase##. 4
,##4 5
QuestionType$$ (
=$$) *
question$$+ 3
.$$3 4
QuestionType$$4 @
,$$@ A
}%% 
;%% 
modifiedQuestions'' )
.'') *
Add''* -
(''- .
newQuestion''. 9
)''9 :
;'': ;
remainingOptions)) (
=))) *
remainingOptions))+ ;
.)); <
Skip))< @
())@ A
$num))A B
)))B C
.))C D
ToList))D J
())J K
)))K L
;))L M
}** 
question,, 
.,, 
Options,, $
=,,% &
question,,' /
.,,/ 0
Options,,0 7
.,,7 8
Take,,8 <
(,,< =
$num,,= >
),,> ?
.,,? @
ToList,,@ F
(,,F G
),,G H
;,,H I
}-- 
modifiedQuestions// !
.//! "
Add//" %
(//% &
question//& .
)//. /
;/// 0
}00 
foreach22 
(22 
var22 
question22 !
in22" $
modifiedQuestions22% 6
)226 7
{33 
while44 
(44 
question44 
.44  
Options44  '
.44' (
Count44( -
<44. /
$num440 1
)441 2
{55 
question66 
.66 
Options66 $
.66$ %
Add66% (
(66( )
new66) ,
Option66- 3
(663 4
)664 5
)665 6
;666 7
}77 
}88 
return:: 
modifiedQuestions:: $
.::$ %

AsReadOnly::% /
(::/ 0
)::0 1
;::1 2
};; 	
}<< 
}== 