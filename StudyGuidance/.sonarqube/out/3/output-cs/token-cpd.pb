‰
C:\Users\Lucah\Documents\School\2023-2024\IT-Project\Team4Talent-WebApp\StudyGuidance\StudyGuidance.AppLogic\IQuizRepository.cs
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
 
Option

 !
>

! "
>

" #
GetSubDomainsAsync

$ 6
(

6 7
List

7 ;
<

; <
int

< ?
>

? @
domainId

A I
)

I J
;

J K
} 
} 