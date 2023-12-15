Œ 
mC:\Users\Gebruiker\itNieuwProj\Team4Talent-WebApp\StudyGuidance\StudGuidance.Api\Controllers\JobController.cs
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
class		 
JobController		 
:		  
ControllerBase		! /
{

 
private 
readonly 
IJobRepository '
_jobRepository( 6
;6 7
public 
JobController 
( 
IJobRepository +
jobRepository, 9
)9 :
{ 	
_jobRepository 
= 
jobRepository *
;* +
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (

GetAllJobs) 3
(3 4
)4 5
{ 	
IReadOnlyList 
< 
Job 
> 
allJobs &
=' (
await) .
_jobRepository/ =
.= >
GetJobsAsync> J
(J K
)K L
;L M
if 
( 
allJobs 
. 
Count 
<=  
$num! "
)" #
{ 
return 
NotFound 
(  
$str  ;
); <
;< =
} 
return 
Ok 
( 
allJobs 
) 
; 
} 	
[ 	
HttpGet	 
( 
$str #
)# $
]$ %
public   
async   
Task   
<   
IActionResult   '
>  ' (

GetJobById  ) 3
(  3 4
int  4 7
id  8 :
)  : ;
{!! 	
Job"" 
job"" 
="" 
await"" 
_jobRepository"" *
.""* +
GetJobByIdAsync""+ :
("": ;
id""; =
)""= >
;""> ?
if$$ 
($$ 
job$$ 
==$$ 
null$$ 
)$$ 
{%% 
return&& 
NotFound&& 
(&&  
$str&&  3
)&&3 4
;&&4 5
}'' 
return)) 
Ok)) 
()) 
job)) 
))) 
;)) 
}** 	
[,, 	
HttpGet,,	 
(,, 
$str,, 
),,  
],,  !
public-- 
async-- 
Task-- 
<-- 
IActionResult-- '
>--' (
GetAllJobsByFilter--) ;
(--; <
[--< =
	FromQuery--= F
]--F G
List--H L
<--L M
int--M P
>--P Q

subdomains--R \
,--\ ]
[--^ _
	FromQuery--_ h
]--h i
bool--j n

workInTeam--o y
,--y z
[--{ |
	FromQuery	--| …
]
--… †
bool
--‡ ‹

workOnSite
--Œ –
)
--– —
{.. 	
IReadOnlyList// 
<// 
Job// 
>// 
allJobsByFilter// .
=/// 0
await//1 6
_jobRepository//7 E
.//E F 
GetJobsByFilterAsync//F Z
(//Z [

subdomains//[ e
,//e f

workInTeam//g q
,//q r

workOnSite//s }
)//} ~
;//~ 
if11 
(11 
allJobsByFilter11 
.11  
Count11  %
<=11& (
$num11) *
)11* +
{22 
return33 
NotFound33 
(33  
$str33  @
)33@ A
;33A B
}44 
return66 
Ok66 
(66 
allJobsByFilter66 %
)66% &
;66& '
}77 	
}88 
}99 ‘I
nC:\Users\Gebruiker\itNieuwProj\Team4Talent-WebApp\StudyGuidance\StudGuidance.Api\Controllers\QuizController.cs
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
;< =
private 
readonly (
IQuestionModificationService 5(
_questionModificationService6 R
;R S
public 
QuizController 
( 
IQuizRepository -
questionRepository. @
,@ A(
IQuestionModificationServiceB ^'
questionModificationService_ z
)z {
{ 	
_questionRepository 
=  !
questionRepository" 4
;4 5(
_questionModificationService (
=) *'
questionModificationService+ F
;F G
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
GetAllQuestions) 8
(8 9
)9 :
{ 	
IReadOnlyList 
< 
Question "
>" #
allQuestions$ 0
=1 2
await3 8
_questionRepository9 L
.L M
GetQuestionsAsyncM ^
(^ _
)_ `
;` a
allQuestions 
= (
_questionModificationService 7
.7 8
ModifyQuestions8 G
(G H
allQuestionsH T
)T U
;U V
if 
( 
allQuestions 
. 
Count "
<=# %
$num& '
)' (
{ 
return 
NotFound 
(  
$str  @
)@ A
;A B
} 
return 
Ok 
( 
allQuestions "
)" #
;# $
} 	
[!! 	
HttpGet!!	 
(!! 
$str!! "
)!!" #
]!!# $
public"" 
async"" 
Task"" 
<"" 
IActionResult"" '
>""' (!
GetAllDomainQuestions"") >
(""> ?
)""? @
{## 	
IReadOnlyList$$ 
<$$ 
Question$$ "
>$$" #
allDomainQuestions$$$ 6
=$$7 8
await$$9 >
_questionRepository$$? R
.$$R S#
GetDomainQuestionsAsync$$S j
($$j k
)$$k l
;$$l m
allDomainQuestions%% 
=%%  (
_questionModificationService%%! =
.%%= >
ModifyQuestions%%> M
(%%M N
allDomainQuestions%%N `
)%%` a
;%%a b
if'' 
('' 
allDomainQuestions'' "
.''" #
Count''# (
<='') +
$num'', -
)''- .
{(( 
return)) 
NotFound)) 
())  
$str))  @
)))@ A
;))A B
}** 
return,, 
Ok,, 
(,, 
allDomainQuestions,, (
),,( )
;,,) *
}-- 	
[// 	
HttpGet//	 
(// 
$str// (
)//( )
]//) *
public00 
async00 
Task00 
<00 
IActionResult00 '
>00' ('
GetAllStandardQuizQuestions00) D
(00D E
)00E F
{11 	
IReadOnlyList22 
<22 
Question22 "
>22" #$
allStandardQuizQuestions22$ <
=22= >
await22? D
_questionRepository22E X
.22X Y)
GetStandardQuizQuestionsAsync22Y v
(22v w
)22w x
;22x y$
allStandardQuizQuestions33 $
=33% &(
_questionModificationService33' C
.33C D
ModifyQuestions33D S
(33S T$
allStandardQuizQuestions33T l
)33l m
;33m n
if55 
(55 $
allStandardQuizQuestions55 (
.55( )
Count55) .
<=55/ 1
$num552 3
)553 4
{66 
return77 
NotFound77 
(77  
$str77  L
)77L M
;77M N
}88 
return:: 
Ok:: 
(:: $
allStandardQuizQuestions:: .
)::. /
;::/ 0
};; 	
[== 	
HttpGet==	 
(== 
$str== &
)==& '
]==' (
public>> 
async>> 
Task>> 
<>> 
IActionResult>> '
>>>' (%
GetAllTinderQuizQuestions>>) B
(>>B C
)>>C D
{?? 	
IReadOnlyList@@ 
<@@ 
Question@@ "
>@@" #"
allTinderQuizQuestions@@$ :
=@@; <
await@@= B
_questionRepository@@C V
.@@V W'
GetTinderQuizQuestionsAsync@@W r
(@@r s
)@@s t
;@@t u"
allTinderQuizQuestionsAA "
=AA# $(
_questionModificationServiceAA% A
.AAA B
ModifyQuestionsAAB Q
(AAQ R"
allTinderQuizQuestionsAAR h
)AAh i
;AAi j
ifCC 
(CC "
allTinderQuizQuestionsCC &
.CC& '
CountCC' ,
<=CC- /
$numCC0 1
)CC1 2
{DD 
returnEE 
NotFoundEE 
(EE  
$strEE  J
)EEJ K
;EEK L
}FF 
returnHH 
OkHH 
(HH "
allTinderQuizQuestionsHH ,
)HH, -
;HH- .
}II 	
[KK 	
HttpGetKK	 
(KK 
$strKK 
)KK 
]KK 
publicLL 
asyncLL 
TaskLL 
<LL 
IActionResultLL '
>LL' (
GetAllDomainsLL) 6
(LL6 7
)LL7 8
{MM 	
IReadOnlyListNN 
<NN 
OptionNN  
>NN  !

allDomainsNN" ,
=NN- .
awaitNN/ 4
_questionRepositoryNN5 H
.NNH I
GetDomainsAsyncNNI X
(NNX Y
)NNY Z
;NNZ [
ifPP 
(PP 

allDomainsPP 
.PP 
CountPP 
<=PP  "
$numPP# $
)PP$ %
{QQ 
returnRR 
NotFoundRR 
(RR  
$strRR  >
)RR> ?
;RR? @
}SS 
returnUU 
OkUU 
(UU 

allDomainsUU  
)UU  !
;UU! "
}VV 	
[XX 	
HttpGetXX	 
(XX 
$strXX 
)XX 
]XX 
publicYY 
asyncYY 
TaskYY 
<YY 
IActionResultYY '
>YY' (
GetAllSubDomainsYY) 9
(YY9 :
[YY: ;
	FromQueryYY; D
]YYD E
ListYYF J
<YYJ K
intYYK N
>YYN O
domainIdYYP X
)YYX Y
{ZZ 	
IReadOnlyList[[ 
<[[ 
Question[[ "
>[[" #!
allSelectedSubDomains[[$ 9
=[[: ;
await[[< A
_questionRepository[[B U
.[[U V&
GetSelectedSubDomainsAsync[[V p
([[p q
domainId[[q y
)[[y z
;[[z {!
allSelectedSubDomains\\ !
=\\" #(
_questionModificationService\\$ @
.\\@ A
ModifyQuestions\\A P
(\\P Q!
allSelectedSubDomains\\Q f
)\\f g
;\\g h
if^^ 
(^^ !
allSelectedSubDomains^^ %
.^^% &
Count^^& +
==^^, .
$num^^/ 0
)^^0 1
{__ 
return`` 
NotFound`` 
(``  
$str``  >
)``> ?
;``? @
}aa 
returncc 
Okcc 
(cc !
allSelectedSubDomainscc +
)cc+ ,
;cc, -
}dd 	
[ff 	
HttpGetff	 
(ff 
$strff !
)ff! "
]ff" #
publicgg 
asyncgg 
Taskgg 
<gg 
IActionResultgg '
>gg' (%
GetAllSubDomainsForFiltergg) B
(ggB C
)ggC D
{hh 	
IReadOnlyListii 
<ii 
Optionii  
>ii  !!
allSelectedSubDomainsii" 7
=ii8 9
awaitii: ?
_questionRepositoryii@ S
.iiS T/
#GetSelectedSubDomainsForFilterAsynciiT w
(iiw x
)iix y
;iiy z
ifkk 
(kk !
allSelectedSubDomainskk %
.kk% &
Countkk& +
==kk, .
$numkk/ 0
)kk0 1
{ll 
returnmm 
NotFoundmm 
(mm  
$strmm  >
)mm> ?
;mm? @
}nn 
returnpp 
Okpp 
(pp !
allSelectedSubDomainspp +
)pp+ ,
;pp, -
}qq 	
}rr 
}ss Ê
[C:\Users\Gebruiker\itNieuwProj\Team4Talent-WebApp\StudyGuidance\StudGuidance.Api\Program.cs
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
$str	} ¯
)
¯ °
;
° ±
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
;? @
builder 
. 
Services 
. 
	AddScoped 
< 
IJobRepository )
,) *
JobDbRepository+ :
>: ;
(; <
)< =
;= >
builder 
. 
Services 
. 
	AddScoped 
< (
IQuestionModificationService 7
,7 8'
QuestionModificationService9 T
>T U
(U V
)V W
;W X
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{   
app!! 
.!! 

UseSwagger!! 
(!! 
)!! 
;!! 
app"" 
."" 
UseSwaggerUI"" 
("" 
)"" 
;"" 
}## 
app%% 
.%% 
UseHttpsRedirection%% 
(%% 
)%% 
;%% 
app'' 
.'' 
UseAuthorization'' 
('' 
)'' 
;'' 
app)) 
.)) 
UseCors)) 
()) 
$str)) !
)))! "
;))" #
app++ 
.++ 
MapControllers++ 
(++ 
)++ 
;++ 
app-- 
.-- 
Run-- 
(-- 
)-- 	
;--	 
