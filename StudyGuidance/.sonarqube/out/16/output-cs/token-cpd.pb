ü8
ûC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudGuidance.Api\Controllers\QuizController.cs
	namespace 	
StudGuidance
 
. 
Api 
. 
Controllers &
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public		 

class		 
QuizController		 
:		  !
ControllerBase		" 0
{

 
private 
readonly 
IQuizRepository (
_questionRepository) <
;< =
public 
QuizController 
( 
IQuizRepository -
questionRepository. @
)@ A
{ 	
_questionRepository 
=  !
questionRepository" 4
;4 5
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
GetAllQuestions) 8
(8 9
)9 :
{ 	
IReadOnlyList 
< 
Question "
>" #
allQuestions$ 0
=1 2
await3 8
_questionRepository9 L
.L M
GetQuestionsAsyncM ^
(^ _
)_ `
;` a
if 
( 
allQuestions 
. 
Count !
<=" $
$num% &
)& '
{ 
return 
NotFound 
(  
$str  @
)@ A
;A B
} 
return 
Ok 
( 
allQuestions "
)" #
;# $
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
GetAllDomains) 6
(6 7
)7 8
{   	
IReadOnlyList!! 
<!! 
Option!!  
>!!  !

allDomains!!" ,
=!!- .
await!!/ 4
_questionRepository!!5 H
.!!H I
GetDomainsAsync!!I X
(!!X Y
)!!Y Z
;!!Z [
if## 
(## 

allDomains## 
.## 
Count## 
<=##  "
$num### $
)##$ %
{$$ 
return%% 
NotFound%% 
(%%  
$str%%  >
)%%> ?
;%%? @
}&& 
return(( 
Ok(( 
((( 

allDomains((  
)((  !
;((! "
})) 	
[++ 	
HttpGet++	 
(++ 
$str++ 
)++ 
]++ 
public,, 
async,, 
Task,, 
<,, 
IActionResult,, '
>,,' (
GetAllSubDomains,,) 9
(,,9 :
[,,: ;
	FromQuery,,; D
],,D E
List,,F J
<,,J K
int,,K N
>,,N O
domainId,,P X
),,X Y
{-- 	
IReadOnlyList.. 
<.. 
Option..  
>..  !
allSubDomains.." /
=..0 1
await..2 7
_questionRepository..8 K
...K L
GetSubDomainsAsync..L ^
(..^ _
domainId.._ g
)..g h
;..h i
if00 
(00 
allSubDomains00 
.00 
Count00 "
==00# %
$num00& '
)00' (
{11 
return22 
NotFound22 
(22  
$str22  >
)22> ?
;22? @
}33 
return55 
Ok55 
(55 
allSubDomains55 #
)55# $
;55$ %
}66 	
[88 	
HttpGet88	 
(88 
$str88 
)88 
]88 
public99 
async99 
Task99 
<99 
IActionResult99 '
>99' (

GetAllJobs99) 3
(993 4
)994 5
{:: 	
IReadOnlyList;; 
<;; 
Job;; 
>;; 
allJobs;; &
=;;' (
await;;) .
_questionRepository;;/ B
.;;B C
GetJobsAsync;;C O
(;;O P
);;P Q
;;;Q R
if== 
(== 
allJobs== 
.== 
Count== 
<===  
$num==! "
)==" #
{>> 
return?? 
NotFound?? 
(??  
$str??  ;
)??; <
;??< =
}@@ 
returnBB 
OkBB 
(BB 
allJobsBB 
)BB 
;BB 
}CC 	
[EE 
HttpGetEE 

(EE
 
$strEE 
)EE 
]EE 
publicFF 
asyncFF	 
TaskFF 
<FF 
IActionResultFF !
>FF! "

GetJobByIdFF# -
(FF- .
intFF. 1
idFF2 4
)FF4 5
{GG 
JobHH 
jobHH 

=HH 
awaitHH 
_questionRepositoryHH &
.HH& '
GetJobByIdAsyncHH' 6
(HH6 7
idHH7 9
)HH9 :
;HH: ;
ifJJ 
(JJ 
jobJJ 

==JJ 
nullJJ 
)JJ 
{KK 
returnLL 

NotFoundLL 
(LL 
$strLL '
)LL' (
;LL( )
}MM 
returnOO 	
OkOO
 
(OO 
jobOO 
)OO 
;OO 
}PP 
[RR 
HttpGetRR 

(RR
 
$strRR 
)RR 
]RR 
publicSS 
asyncSS 
TaskSS 
<SS 
IActionResultSS '
>SS' (
GetAllJobsByFilterSS) ;
(SS; <
[SS< =
	FromQuerySS= F
]SSF G
ListSSH L
<SSL M
stringSSM S
>SSS T

subdomainsSSU _
,SS_ `
[SSa b
	FromQuerySSb k
]SSk l
boolSSm q

workInTeamSSr |
,SS| }
[SS~ 
	FromQuery	SS à
]
SSà â
bool
SSä é

workOnSite
SSè ô
)
SSô ö
{TT 	
IReadOnlyListUU 
<UU 
JobUU 
>UU 
allJobsByFilterUU .
=UU/ 0
awaitUU1 6
_questionRepositoryUU7 J
.UUJ K 
GetJobsByFilterAsyncUUK _
(UU_ `

subdomainsUU` j
,UUj k

workInTeamUUl v
,UUv w

workOnSite	UUx Ç
)
UUÇ É
;
UUÉ Ñ
ifWW 
(WW 
allJobsByFilterWW 
.WW  
CountWW  %
<=WW& (
$numWW) *
)WW* +
{XX 
returnYY 
NotFoundYY 
(YY  
$strYY  @
)YY@ A
;YYA B
}ZZ 
return\\ 
Ok\\ 
(\\ 
allJobsByFilter\\ %
)\\% &
;\\& '
}]] 	
}^^ 
}__ ˇ
ãC:\Users\Gebruiker\OneDrive - PXL\Documenten\pxl\3AONb\IT-project\NieuwProject\Team4Talent-WebApp\StudyGuidance\StudGuidance.Api\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddCors 
( 
options  
=>! #
{ 
options		 
.		 
	AddPolicy		 
(		 
$str		 +
,		+ ,
builder

 
=>

 
builder

 
.

 
WithOrigins

 &
(

& '
$str

' ?
)

? @
. 
AllowAnyHeader )
() *
)* +
. 
AllowAnyMethod )
() *
)* +
)+ ,
;, -
} 
) 
; 
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
var 
connectionString 
= 
builder 
. 
Configuration ,
., -
GetConnectionString- @
(@ A
$strA T
)T U
??V X
throwY ^
new_ b%
InvalidOperationExceptionc |
(| }
$str	} Ø
)
Ø ∞
;
∞ ±
builder 
. 
Services 
. 
AddDbContext 
< "
StudyGuidanceDbContext 4
>4 5
(5 6
options6 =
=>> @
options 
. 
UseSqlServer 
( 
connectionString )
)) *
)* +
;+ ,
builder 
. 
Services 
. 
	AddScoped 
< 
IQuizRepository *
,* +
QuizDbRepository, <
>< =
(= >
)> ?
;? @
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app 
. 

UseSwagger 
( 
) 
; 
app   
.   
UseSwaggerUI   
(   
)   
;   
}!! 
app## 
.## 
UseHttpsRedirection## 
(## 
)## 
;## 
app%% 
.%% 
UseAuthorization%% 
(%% 
)%% 
;%% 
app'' 
.'' 
UseCors'' 
('' 
$str'' !
)''! "
;''" #
app)) 
.)) 
MapControllers)) 
()) 
))) 
;)) 
app++ 
.++ 
Run++ 
(++ 
)++ 	
;++	 
