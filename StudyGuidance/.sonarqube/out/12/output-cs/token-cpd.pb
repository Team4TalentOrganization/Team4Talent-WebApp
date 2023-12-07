¨
™C:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudyGuidance.AppLogic\IQuizRepository.cs
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
< 
Option !
>! "
>" #
GetDomainsAsync$ 3
(3 4
)4 5
;5 6
Task		 
<		 
IReadOnlyList		 
<		 
Option		 !
>		! "
>		" #
GetSubDomainsAsync		$ 6
(		6 7
List		7 ;
<		; <
int		< ?
>		? @
domainId		A I
)		I J
;		J K
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
 
Job

 
>

 
>

  
GetJobsAsync

! -
(

- .
)

. /
;

/ 0
Task 
< 
IReadOnlyList 
< 
Job 
> 
>   
GetJobsByFilterAsync! 5
(5 6
List6 :
<: ;
string; A
>A B

subdomainsC M
,M N
boolO S

workInTeamT ^
,^ _
bool` d

workOnSitee o
)o p
;p q
Task 
< 
Job 

>
 
GetJobByIdAsync 
( 
int 
id  "
)" #
;# $
} 
} 